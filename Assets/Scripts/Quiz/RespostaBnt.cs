using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RespostaBnt : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField]
    private TextMeshProUGUI answerText;

    public void SetAnswerText(string newText)
    {
        answerText.text = newText;

    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }
        public void OnClick()
    {
        if (isCorrect)
        {
            Debug.Log("Correta ");
        }
        else
            Debug.Log("Erou");
    }
    
}