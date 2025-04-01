using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomSentenceGame : MonoBehaviour
{
	public Text legacyText;
	public Text messageText;
	public Button button1;
	public Button button2;
	public Button button3;

	public string[] sentences = {
		"Our ... consists of five people \n Наша ... состоит из пяти человек",
		"My ... name is Masha \n Мою ... зовут Маша",
		"My mom and ... have been together for 20 years \n Мои мама и ... вместе уже 20 лет"
	};

	public string[] answers = { "Family", "Sister's", "Dad" };

	public int currentIndex;

	void Start()
	{
		ShowRandomSentence();
		button1.onClick.AddListener(() => CheckAnswer(button1));
		button2.onClick.AddListener(() => CheckAnswer(button2));
		button3.onClick.AddListener(() => CheckAnswer(button3));
	}

	void ShowRandomSentence()
	{
		legacyText.text = sentences[currentIndex];

		// Увеличиваем индекс для следующего предложения
		currentIndex += 1;
	}

	void CheckAnswer(Button button)
	{
		int currentSentenceIndex = (currentIndex - 1) % sentences.Length; // Получаем индекс текущего предложения

		if (legacyText.text.Contains("...") && button.GetComponentInChildren<Text>().text == answers[currentSentenceIndex])
		{
			StartCoroutine(ShowMessage("Правильно! \nWell done!", 3f));
			ShowRandomSentence();
		}
		else
		{
			StartCoroutine(ShowMessage("Неправильно. Попробуй ещё раз \nIncorrectly. Try again", 3f));
		}
	}

	IEnumerator ShowMessage(string message, float delay)
	{
		messageText.text = message;
		yield return new WaitForSeconds(delay);
		messageText.text = "";

		// Небольшая задержка перед показом нового предложения
		yield return new WaitForSeconds(0.1f);
	}
}