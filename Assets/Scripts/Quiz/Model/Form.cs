using NoTask.Models;
using UnityEngine;

namespace Quiz.Model
{
    [CreateAssetMenu(fileName = "form", menuName = "Quiz/form", order = 0)]
    public class Form : ScriptableObject
    {
        [field: SerializeField] private Questions questions;

        public Question<string> GetQuestion(int questionIndex) => questions.questions[questionIndex];
        public int QuestionsCount => questions.questions.Length;
        public int[] GetAnswers(int questionIndex) => questions.questions[questionIndex].correctOption;
        public void SetQuestions(Questions values) => questions = values;
    }
}