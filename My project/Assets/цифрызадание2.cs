using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
	public Text messageText;

	public void CheckButtonText(Button button)
	{
		if (button.GetComponentInChildren<Text>().text == "Nyne" || button.GetComponentInChildren<Text>().text == "Fife" || button.GetComponentInChildren<Text>().text == "Too")
		{
			StartCoroutine(ShowMessage("Правильно! \nWell done!", 3f));
		}
		else
		{
			StartCoroutine(ShowMessage("Неправильно.\nПопробуй ещё раз \nIncorrectly. Try again", 4f));
		}

		IEnumerator ShowMessage(string message, float delay)
		{
			messageText.text = message;
			yield return new WaitForSeconds(delay);
			messageText.text = "";
		}
	}
}