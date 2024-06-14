using NoTask.Models;
using Quiz.Model;
using UnityEngine;

namespace Quiz
{
    /// <summary>
    /// logic of the quiz
    /// </summary>
    public class QuizMachine : MonoBehaviour
    {
        [SerializeField] private Form form;

        private int _currentQuestionIndex;

        private bool IsLastQuestion => _currentQuestionIndex == form.QuestionsCount - 1;

        public void NextQuestion()
        {
            if (IsLastQuestion)
                return;

            _currentQuestionIndex = (_currentQuestionIndex + 1) % form.QuestionsCount;
        }
        
        public int[] GetCorrectAnswers() => form.GetAnswers(_currentQuestionIndex);

        public Question<string> GetCurrentQuestion() => form.GetQuestion(_currentQuestionIndex);
    }
}