using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class VoiceRecorder : MonoBehaviour
{
    private AudioClip recordedClip;
    private bool isRecording = false;
    public Text infoText; // Используйте TextMeshProUGUI, если используете TMP
    private const string folderId = "b1g0qtul768qdokl24ob";
    private const string iamToken = "t1.9euelZrLyI_IjZucjYzNmsnNnMfHx-3rnpWanZCMjo-SmJSQx4uXzZLOns3l8_cjTAtB-e83MFoK_d3z92N6CEH57zcwWgr9zef1656Vmo6KlImOzZqcjJidysmYjc6O7_zF656Vmo6KlImOzZqcjJidysmYjc6O.6m006V9nooRa-Uf9m-xYrg0cp6RGZewWC-di4Cq3toD6FemWvEAbtFuddXJ2o895g7IAOHSS9LawOwjlVO-YDg";
    public AudioCheck audioCheck;

    // Переменная для хранения ожидаемого слова
    private string wordCheck;

    public async void ToggleRecording()
    {
        if (isRecording)
        {
            await StopRecording();
        }
        else
        {
            StartRecording();
        }
    }

    private void StartRecording()
    {
        recordedClip = Microphone.Start(null, false, 10, 44100);
        isRecording = true;
        UpdateInfoText("Запись..");
    }

    private async Task StopRecording()
    {
        Microphone.End(null);
        isRecording = false;
        UpdateInfoText("Запись остановлена.");

        try
        {
            var http = new HttpClient();
            http.BaseAddress = new Uri("https://stt.api.cloud.yandex.net/");
            var bytes = OggVorbis.VorbisPlugin.GetOggVorbis(recordedClip);
            var content = new ByteArrayContent(bytes);
            var request = new HttpRequestMessage(HttpMethod.Post, $"speech/v1/stt:recognize?topic=general&lang=en-EN&folderId={folderId}");
            request.Content = content;
            request.Content.Headers.ContentLength = bytes.Length;
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/ogg");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", iamToken);
            var response = await http.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var yaSpeechResponse = JsonUtility.FromJson<YaSpeechResponse>(json);
            Debug.Log(yaSpeechResponse.result); // Выводим ответ сервера в консоль
        }
        catch (Exception exc)
        {
            Debug.LogError(exc.Message); // Логируем ошибки
        }
    }

}

[Serializable]
public class YaSpeechResponse
{
    public string result;
}
