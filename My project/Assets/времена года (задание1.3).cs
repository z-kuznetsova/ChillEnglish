using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomText3 : MonoBehaviour
{
	public Text seasonText;
	public string[] seasons = { "ЛЕТНИЙ", "ЗИМНИЙ", "ВЕСЕННИЙ", "ОСЕННИЙ" };
	public Text textDisplay3;
	public string[] randomTexts3 = { "September", "October", "November" };
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
		int randomIndex3 = Random.Range(0, randomTexts3.Length);
		textDisplay3.text = randomTexts3[randomIndex3];
	}

	public void CheckText()
	{
		string buttonText = checkButton.GetComponentInChildren<Text>().text;
		string displayedText = textDisplayseason.text;

		if (displayedText == "ЗИМНИЙ" && (buttonText == "December" || buttonText == "January" || buttonText == "February"))
		{
			StartCoroutine(ShowMessage("Правильно! \nWell done!", 5f));
			ChangeSeason();
			DisplayRandomText();
		}
		else if (displayedText == "ЛЕТНИЙ" && (buttonText == "June" || buttonText == "July" || buttonText == "August"))
		{
			StartCoroutine(ShowMessage("Правильно! \nWell done!", 5f));
			ChangeSeason();
			DisplayRandomText();
		}
		else if (displayedText == "ВЕСЕННИЙ" && (buttonText == "March" || buttonText == "April" || buttonText == "May"))
		{
			StartCoroutine(ShowMessage("Правильно! \nWell done!", 5f));
			ChangeSeason();
			DisplayRandomText();
		}
		else if (displayedText == "ОСЕННИЙ" && (buttonText == "September" || buttonText == "October" || buttonText == "November"))
		{
			StartCoroutine(ShowMessage("Правильно! \nWell done!", 5f));
			ChangeSeason();
			DisplayRandomText();
		}
		else
		{
			StartCoroutine(ShowMessage("Неправильно. Попробуй ещё раз \nIncorrectly. Try again", 5f));
		}
	}

	IEnumerator ShowMessage(string message, float delay)
	{
		messageText.text = message;
		yield return new WaitForSeconds(delay);
		messageText.text = "";
	}
}