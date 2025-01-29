using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "points", menuName = "Quiz/Points", order = 0)]
    public class Points : ScriptableObject
    {
        [SerializeField] private int totalQuestions;//total de perguntas
        [SerializeField] private int correctAnswers;//respostas corretas
        
        public int TotalQuestions => totalQuestions;
        
        public int CorrectAnswers => correctAnswers;
        
        public void AddTotalPoints(int points)
        {
            totalQuestions += points;
        }
        
        public void AddCurrentPoints(int points)
        {
            correctAnswers += points;
        }

        public void Delete()
        {
            Debug.LogWarning("Deleting Points...");
            totalQuestions = 0;
            correctAnswers = 0;
        }
    }
}