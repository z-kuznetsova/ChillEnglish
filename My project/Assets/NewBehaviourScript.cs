using UnityEngine;
using UnityEngine.UI;

public class MyButtonSound : MonoBehaviour
{
    public AudioClip buttonClickSound; // ��������� � ������
    private Button button;
    private AudioSource audioSource;

    void Start()
    {
        button = GetComponent<Button>();

        // ��������� AudioSource � ���� �� �������, ��� � ButtonSound
        audioSource = gameObject.AddComponent<AudioSource>();

        // ����������� ���� ������
        button.onClick.AddListener(PlayButtonClickSound);
    }

    public void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}

