using DefaultNamespace;
using TMPro;
using UnityEngine;

public class PointsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI correctAnswersText;
    [SerializeField] private TextMeshProUGUI totalQuestionsText;
    
    private void Start()
    {
        var points = Resources.Load<Points>("points");
        points.Load();

        correctAnswersText.text = $"{points.CorrectAnswers}";
        totalQuestionsText.text = $"/ {points.TotalQuestions}";
    }
}
