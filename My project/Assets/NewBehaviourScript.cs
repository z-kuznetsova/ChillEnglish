using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MyButtonSound : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip buttonClickSound; // ��������� � ������
    [Range(0f, 1f)]
    public float volume = 1f; // ��������� �����

    private Button button;
    private AudioSource audioSource;

    void Awake()
    {
        // �������� ��������� Button
        button = GetComponent<Button>();

        // ���������, ���� �� ��� AudioSource, ���� ��� - ��������� ���
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ����������� ���� ������
        button.onClick.AddListener(PlayButtonClickSound);
    }

    public void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            audioSource.volume = volume; // ������������� ���������
            audioSource.PlayOneShot(buttonClickSound);
        }
        else
        {
            Debug.LogWarning("AudioClip �� �������� ��� ������ " + gameObject.name);
        }
    }
}
