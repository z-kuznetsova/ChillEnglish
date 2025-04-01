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
		"Our ... consists of five people \n ���� ... ������� �� ���� �������",
		"My ... name is Masha \n ��� ... ����� ����",
		"My mom and ... have been together for 20 years \n ��� ���� � ... ������ ��� 20 ���"
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

		// ����������� ������ ��� ���������� �����������
		currentIndex += 1;
	}

	void CheckAnswer(Button button)
	{
		int currentSentenceIndex = (currentIndex - 1) % sentences.Length; // �������� ������ �������� �����������

		if (legacyText.text.Contains("...") && button.GetComponentInChildren<Text>().text == answers[currentSentenceIndex])
		{
			StartCoroutine(ShowMessage("���������! \nWell done!", 3f));
			ShowRandomSentence();
		}
		else
		{
			StartCoroutine(ShowMessage("�����������. �������� ��� ��� \nIncorrectly. Try again", 3f));
		}
	}

	IEnumerator ShowMessage(string message, float delay)
	{
		messageText.text = message;
		yield return new WaitForSeconds(delay);
		messageText.text = "";

		// ��������� �������� ����� ������� ������ �����������
		yield return new WaitForSeconds(0.1f);
	}
}