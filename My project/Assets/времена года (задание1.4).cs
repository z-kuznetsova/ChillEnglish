using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomText4 : MonoBehaviour
{
	public Text seasonText;
	public string[] seasons = { "������", "������", "��������", "�������" };
	public Text textDisplay4;
	public string[] randomTexts4 = { "July", "August", "June" };
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
		int randomIndex4 = Random.Range(0, randomTexts4.Length);
		textDisplay4.text = randomTexts4[randomIndex4];
	}

	public void CheckText()
	{
		string buttonText = checkButton.GetComponentInChildren<Text>().text;
		string displayedText = textDisplayseason.text;

		if (displayedText == "������" && (buttonText == "December" || buttonText == "January" || buttonText == "February"))
		{
			StartCoroutine(ShowMessage("���������! \nWell done!", 8f));
			ChangeSeason();
			DisplayRandomText();
		}
		else if (displayedText == "������" && (buttonText == "June" || buttonText == "July" || buttonText == "August"))
		{
			StartCoroutine(ShowMessage("���������! \nWell done!", 8f));
			ChangeSeason();
			DisplayRandomText();
		}
		else if (displayedText == "��������" && (buttonText == "March" || buttonText == "April" || buttonText == "May"))
		{
			StartCoroutine(ShowMessage("���������! \nWell done!", 8f));
			ChangeSeason();
			DisplayRandomText();
		}
		else if (displayedText == "�������" && (buttonText == "September" || buttonText == "October" || buttonText == "November"))
		{
			StartCoroutine(ShowMessage("���������! \nWell done!", 8f));
			ChangeSeason();
			DisplayRandomText();
		}
		else
		{
			StartCoroutine(ShowMessage("�����������. �������� ��� ��� \nIncorrectly. Try again", 8f));
		}
	}

	IEnumerator ShowMessage(string message, float delay)
	{
		messageText.text = message;
		yield return new WaitForSeconds(delay);
		messageText.text = "";
	}
}