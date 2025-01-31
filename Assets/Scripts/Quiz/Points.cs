using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "points", menuName = "Quiz/Points", order = 0)]
    public class Points : ScriptableObject
    {
        [SerializeField] private int totalQuestions; //total de perguntas
        [SerializeField] private int correctAnswers; //respostas corretas

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

        public void Load()
        {
            Debug.LogWarning("Loading Points...");
            totalQuestions = PlayerPrefs.GetInt("totalQuestions");
            correctAnswers = PlayerPrefs.GetInt("correctAnswers");
        }

        public void Save()
        {
            Debug.LogWarning("Saving Points...");
            PlayerPrefs.SetInt("totalQuestions", totalQuestions);
            PlayerPrefs.SetInt("correctAnswers", correctAnswers);
            PlayerPrefs.Save();
        }

        public void Delete()
        {
            Debug.LogWarning("Deleting Points...");
            PlayerPrefs.DeleteAll();
            totalQuestions = 0;
            correctAnswers = 0;
        }
    }
}