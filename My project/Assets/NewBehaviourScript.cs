using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MyButtonSound : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip buttonClickSound; // Аудиоклип с звуком
    [Range(0f, 1f)]
    public float volume = 1f; // Громкость звука

    private Button button;
    private AudioSource audioSource;

    void Awake()
    {
        // Получаем компонент Button
        button = GetComponent<Button>();

        // Проверяем, есть ли уже AudioSource, если нет - добавляем его
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Присваиваем звук кнопке
        button.onClick.AddListener(PlayButtonClickSound);
    }

    public void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            audioSource.volume = volume; // Устанавливаем громкость
            audioSource.PlayOneShot(buttonClickSound);
        }
        else
        {
            Debug.LogWarning("AudioClip не назначен для кнопки " + gameObject.name);
        }
    }
}
