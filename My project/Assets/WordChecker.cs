using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyWordCheck : MonoBehaviour
{
    public List<Transform> panels; // Список для хранения позиций панелей
    public List<Transform> letters; // Список для хранения позиций ячеек с буквами
    public Text messageText; // Ссылка на текстовый объект "Сообщение"

    public void UpdateLetterPosition(Transform letterTransform)
    {
        // Находим индекс буквы в списке letters
        int index = letters.IndexOf(letterTransform);

        if (index != -1)
        {
            // Обновляем позицию буквы в списке letters
            letters[index] = letterTransform;
        }
    }
    void MessageTrue()
    {
        messageText.text = "Правильно! Ты молодец!";
        Debug.Log("The word is correct!");
    }

    void MessageFalse()
    {
        messageText.text = "Неправильно. Попробуй ещё раз)";
        Debug.Log("The word is incorrect!");
    }    
    public void CheckWordSkirts()
    {
        if (Vector3.Distance(letters[0].position, panels[0].position) <= 80 && 
            Vector3.Distance(letters[1].position, panels[1].position) <= 80 && 
            Vector3.Distance(letters[2].position, panels[2].position) <= 80 &&
            Vector3.Distance(letters[3].position, panels[3].position) <= 80 &&
            Vector3.Distance(letters[4].position, panels[4].position) <= 80)
        {
            MessageTrue();
        }
        else
        {
            MessageFalse();
        }
    }
    public void CheckTask()
    {
        if (Vector3.Distance(letters[0].position, panels[0].position) <= 80 && Vector3.Distance(letters[1].position, panels[1].position) <= 80)
        {
            MessageTrue();
        }
        else
        {
            MessageFalse();
        }
    }


    public void CheckWord()
    {
        // Проверка правильности построения слова с погрешностью в 50
        if (Vector3.Distance(letters[0].position, panels[0].position) <= 50 &&
            (Vector3.Distance(letters[1].position, panels[1].position) <= 50 ||
             Vector3.Distance(letters[2].position, panels[1].position) <= 50 ||
             Vector3.Distance(letters[3].position, panels[1].position) <= 50) &&
            (Vector3.Distance(letters[4].position, panels[2].position) <= 50 ||
             Vector3.Distance(letters[5].position, panels[2].position) <= 50) &&
            (Vector3.Distance(letters[1].position, panels[3].position) <= 50 ||
             Vector3.Distance(letters[2].position, panels[3].position) <= 50 ||
             Vector3.Distance(letters[3].position, panels[3].position) <= 50) &&
            (Vector3.Distance(letters[4].position, panels[4].position) <= 50 ||
             Vector3.Distance(letters[5].position, panels[4].position) <= 50) &&
            (Vector3.Distance(letters[1].position, panels[5].position) <= 50 ||
             Vector3.Distance(letters[2].position, panels[5].position) <= 50 ||
             Vector3.Distance(letters[3].position, panels[5].position) <= 50))
        {
            MessageTrue();
        }
        else
        {
            MessageFalse();
        }
    }
}
