using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI correctAnswersText;
    [SerializeField] private TextMeshProUGUI totalQuestionsText;

    private void Start()
    {
        int correctAnswers = PlayerPrefs.GetInt("CorrectAnswers", 0);
        int totalQuestions = PlayerPrefs.GetInt("TotalQuestions", 0);

        correctAnswersText.text = $"{correctAnswers}";
        totalQuestionsText.text = $"/ {totalQuestions}";
    }
}
