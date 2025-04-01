using UnityEngine;
using UnityEngine.UI;

public class MyButtonSound : MonoBehaviour
{
    public AudioClip buttonClickSound; // Аудиоклип с звуком
    private Button button;
    private AudioSource audioSource;

    void Start()
    {
        button = GetComponent<Button>();

        // Добавляем AudioSource к тому же объекту, что и ButtonSound
        audioSource = gameObject.AddComponent<AudioSource>();

        // Присваиваем звук кнопке
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

