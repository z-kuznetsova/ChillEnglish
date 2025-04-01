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
}

