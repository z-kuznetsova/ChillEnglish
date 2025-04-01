using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomText : MonoBehaviour
{
	public Text seasonText;
	public Text textDisplay;
	public string[] seasons = { "������", "������", "��������", "�������" };
	public string[] randomTexts = { "December", "January", "February" };
	public Button checkButton;
	public Text messageText;
	public Text textDisplayseason;

	void Start()
	{
		ChangeSeason();
		DisplayRandomText();
		checkButton.onClick.AddListener(CheckText);
	}

	public void ChangeSeason()
	{
		int randomIndex = Random.Range(0, seasons.Length);
		seasonText.text = seasons[randomIndex];
	}

	public void DisplayRandomText()
	{
		int randomIndex = Random.Range(0, randomTexts.Length);
		textDisplay.text = randomTexts[randomIndex];
	}

	public void CheckText()
	{
		string buttonText = checkButton.GetComponentInChildren<Text>().text;
		string displayedText = textDisplayseason.text;

		if (displayedText == "������" && (buttonText == "December" || buttonText == "January" || buttonText == "February"))
		{
			StartCoroutine(ShowMessage("���������! \nWell done!", 5f));
			ChangeSeason();
			DisplayRandomText();
		}
		else if (displayedText == "������" && (buttonText == "June" || buttonText == "July" || buttonText == "August"))
		{
			StartCoroutine(ShowMessage("���������! \nWell done!", 5f));
			ChangeSeason();
			DisplayRandomText();
		}
		else if (displayedText == "��������" && (buttonText == "March" || buttonText == "April" || buttonText == "May"))
		{
			StartCoroutine(ShowMessage("���������! \nWell done!", 5f));
			ChangeSeason();
			DisplayRandomText();
		}
		else if (displayedText == "�������" && (buttonText == "September" || buttonText == "October" || buttonText == "November"))
		{
			StartCoroutine(ShowMessage("���������! \nWell done!", 5f));
			ChangeSeason();
			DisplayRandomText();
		}
		else
		{
			StartCoroutine(ShowMessage("�����������. �������� ��� ��� \nIncorrectly. Try again", 5f));
		}
	}

	IEnumerator ShowMessage(string message, float delay)
	{
		messageText.text = message;
		yield return new WaitForSeconds(delay);
		messageText.text = "";
	}
}