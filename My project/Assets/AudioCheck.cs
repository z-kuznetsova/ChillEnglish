using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioCheck : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void LoadAudioFromUrl(string url)
    {
        StartCoroutine(DownloadAudio(url));
    }

    private IEnumerator DownloadAudio(string url)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Ошибка загрузки аудиофайла: {www.error}");
            }
            else
            {
                AudioClip audioClip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = audioClip;
                audioSource.Play();
                Debug.Log("Аудиофайл загружен и воспроизводится.");
            }
        }
    }
}
