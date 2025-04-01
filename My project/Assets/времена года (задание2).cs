using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGuessingGame : MonoBehaviour
{
	public List<Sprite> images; // Список изображений
	public Image imageDisplay; // Компонент для отображения изображения
	public Text messageText;

	private string correctAnswer; // Правильный ответ

	void Start()
	{
		ShowRandomImage();
	}

	void ShowRandomImage()
	{
		int randomIndex = Random.Range(0, images.Count); // Генерируем случайный индекс изображения
		imageDisplay.sprite = images[randomIndex]; // Отображаем случайное изображение
		correctAnswer = images[randomIndex].name; // Получаем название изображения как правильный ответ
	}

	public void CheckAnswer(Button button)
	{
		if (button.GetComponentInChildren<Text>().text == correctAnswer)
		{
			ShowRandomImage(); // Показываем следующее случайное изображение
			StartCoroutine(ShowMessage("Правильно! \nWell done!", 3f));
		}
		else
		{
			StartCoroutine(ShowMessage("Неправильно. Попробуй ещё раз \nIncorrectly. Try again", 4f));
		}

		IEnumerator ShowMessage(string message, float delay)
		{
			messageText.text = message;
			yield return new WaitForSeconds(delay);
			messageText.text = "";
		}
	}
}