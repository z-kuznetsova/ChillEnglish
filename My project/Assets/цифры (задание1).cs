using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberComparison : MonoBehaviour
{
    public GameObject[] numberImages;
    public Vector3[] initialPositions;
    public GameObject backgroundPanel;
    public Text randomTextPanel;
    public Text messageText;
    int currentWordIndex = 0;



    void Start()
    {
        SetRandomText();
        SaveInitialPositions();
    }

    void SetRandomText()
    {
        string[] numberWords = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        randomTextPanel.text = numberWords[currentWordIndex];

        currentWordIndex++;
        if (currentWordIndex >= numberWords.Length)
        {
            currentWordIndex = 0; // Сбросить индекс на 0, когда достигнут конец списка
        }
    }

    void SaveInitialPositions()
    {
        initialPositions = new Vector3[numberImages.Length];
        for (int i = 0; i < numberImages.Length; i++)
        {
            initialPositions[i] = numberImages[i].transform.position;
        }
    }

    void Update()
    {
        float minDistance = float.MaxValue;
        GameObject closestNumber = null;

        for (int i = 0; i < numberImages.Length; i++)
        {
            float distance = Vector3.Distance(numberImages[i].transform.position, backgroundPanel.transform.position);

            if (distance < 80f && distance < minDistance)
            {
                minDistance = distance;
                closestNumber = numberImages[i];
            }
        }

        if (closestNumber != null)
        {
            string closestNumberName = closestNumber.name.Replace("(Clone)", "").Trim();

            if (randomTextPanel.text == closestNumberName)
            {
                StartCoroutine(ShowMessageAndSetRandomText("Правильно! \nWell done!", 2f));
                MoveImageBackToInitialPosition(closestNumber);
            }
            else
            {
                StartCoroutine(ShowMessage("Неправильно.\nПопробуй ещё раз \nIncorrectly. Try again", 3f));
                MoveImageBackToInitialPosition(closestNumber);
            }
        }
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        messageText.text = message;
        yield return new WaitForSeconds(delay);
        messageText.text = "";
    }

    void MoveImageBackToInitialPosition(GameObject image)
    {
        StartCoroutine(MoveImageWithDelay(image, 1.5f));
    }

    IEnumerator MoveImageWithDelay(GameObject image, float delay)
    {
        yield return new WaitForSeconds(delay);

        int index = System.Array.IndexOf(numberImages, image);
        image.transform.position = initialPositions[index];
    }

    IEnumerator ShowMessageAndSetRandomText(string message, float delay)
    {
        messageText.text = message;
        yield return new WaitForSeconds(delay);
        messageText.text = "";
        yield return new WaitForSeconds(0.5f); // Задержка на 1 секунды
        SetRandomText();

    }
}