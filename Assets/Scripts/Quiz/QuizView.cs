using System;
using System.Collections.Generic;
using Quiz.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    /// <summary>
    /// view of the quiz
    /// </summary>
    public class QuizView : MonoBehaviour
    {
        [SerializeField] private ButtonsGroup buttonsGroup;
        [SerializeField] private TMP_Text timer;
        [SerializeField] private TMP_Text titleQuestion;
        [SerializeField] private List<AnswerButton> answerButtons;
        [SerializeField] private Button markQuestionButton;
        [SerializeField] private Button nextButton;

        [SerializeField] private Color wrongColor;
        [SerializeField] private Color correctColor;

        public event Action OnMarkedAnswer;
        public event Action OnNextQuestion;

        private void OnEnable()
        {
            nextButton.onClick.AddListener(NextQuestion);
            markQuestionButton.onClick.AddListener(MarkQuestion);
        }

        private void OnDisable()
        {
            nextButton.onClick.RemoveAllListeners();
            markQuestionButton.onClick.RemoveAllListeners();
        }

        private void NextQuestion() => OnNextQuestion?.Invoke();

        private void MarkQuestion() => OnMarkedAnswer?.Invoke();

        public void SetTitleQuestion(string question) => titleQuestion.SetText(question);

        public void SetAnswers(string[] answers)
        {
            for (var i = 0; i < answerButtons.Count; i++)
            {
                answerButtons[i].Text = answers[i];
            }
        }

        public void SetupButtons(int bufferCapacity = 1)
        {
            buttonsGroup.CreateBuffer(bufferCapacity);
            if (buttonsGroup.Buttons.Length == 0 || buttonsGroup.Buttons == null)
                buttonsGroup.Buttons = answerButtons.ToArray();
        }

        public void Reset()
        {
            buttonsGroup.Reset();
            foreach (var answerButton in answerButtons) answerButton.Deselect();
        }

        public void ClosePopup() => NextQuestion();

        public void UpdateTimer(float time) => timer.SetText($"{(int)time / 60:00}:{(int)time % 60:00}");

        public void UpdateButtonColor(int index)
        {
            foreach (var answerButton in answerButtons) answerButton.UpdateColor(wrongColor);
            answerButtons[index].UpdateColor(correctColor);
        }
    }
}