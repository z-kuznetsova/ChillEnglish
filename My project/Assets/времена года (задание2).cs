using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGuessingGame : MonoBehaviour
{
	public List<Sprite> images; // ������ �����������
	public Image imageDisplay; // ��������� ��� ����������� �����������
	public Text messageText;

	private string correctAnswer; // ���������� �����

	void Start()
	{
		ShowRandomImage();
	}

	void ShowRandomImage()
	{
		int randomIndex = Random.Range(0, images.Count); // ���������� ��������� ������ �����������
		imageDisplay.sprite = images[randomIndex]; // ���������� ��������� �����������
		correctAnswer = images[randomIndex].name; // �������� �������� ����������� ��� ���������� �����
	}

	public void CheckAnswer(Button button)
	{
		if (button.GetComponentInChildren<Text>().text == correctAnswer)
		{
			ShowRandomImage(); // ���������� ��������� ��������� �����������
			StartCoroutine(ShowMessage("���������! \nWell done!", 3f));
		}
		else
		{
			StartCoroutine(ShowMessage("�����������. �������� ��� ��� \nIncorrectly. Try again", 4f));
		}

		IEnumerator ShowMessage(string message, float delay)
		{
			messageText.text = message;
			yield return new WaitForSeconds(delay);
			messageText.text = "";
		}
	}
}