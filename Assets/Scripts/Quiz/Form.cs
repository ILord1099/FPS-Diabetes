using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    [CreateAssetMenu(fileName = "form", menuName = "Quiz/Form", order = 0)]
    public class Form : ScriptableObject
    {
        [SerializeField] private List<Question> questions;
        
        public Question GetQuestion(int index) => questions[index];
        
        public int GetQuestionsCount() => questions.Count;
    }

    [System.Serializable]
    public struct Question
    {
        [TextArea(2, 5)] public string question;
        public List<Answer> answers;
    }

    [System.Serializable]
    public struct Answer
    {
        [TextArea(2, 5)] public string text;
        public bool isCorrect;
    }

}