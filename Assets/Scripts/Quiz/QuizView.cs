using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Quiz
{
    public class QuizView : MonoBehaviour
    {
        [SerializeField] private float delayNextQuestion = 1.5f;//delay para a próxima pergunta
        [SerializeField] private Timer timer;
        [SerializeField] private List<AnswerButton> answerButtons;
        [SerializeField] private TMP_Text questionText;

        private AnswerButton _currentSelectedButton;
        
        public event Action OnEndTimeQuestion;

        #region OnEnable/OnDisable

        private void OnEnable()
        {
            timer.OnEnd += EndTimer;

            foreach (var button in answerButtons)
            {
                button.OnAnswerSelected += OnAnswerSelected;
            }
        }

        private void OnDisable()
        {
            timer.OnEnd -= EndTimer;
            
            foreach (var button in answerButtons)
            {
                button.OnAnswerSelected -= OnAnswerSelected;
            }
        }

        #endregion

        private void EndTimer()
        {
            foreach (var button in answerButtons)
            {
                button.SetInteractable(false);
                button.UpdateAnswerColor();
            }

            OnEndTimeQuestion?.Invoke();
        }

        public void SetQuestion(string question) => questionText.text = question;
        
        public void SetAnswers(List<Answer> answers)
        {
            StopCoroutine(nameof(DelaySetAnswers));
            StartCoroutine(DelaySetAnswers(answers));
        }
        
        private IEnumerator DelaySetAnswers(List<Answer> answers)
        {
            yield return new WaitForSeconds(delayNextQuestion);
            
            for (var i = 0; i < answerButtons.Count; i++)
            {
                answerButtons[i].SetText(answers[i].text);
                answerButtons[i].IsCorrect = answers[i].isCorrect;
                answerButtons[i].Deselect();
                answerButtons[i].SetInteractable(true);
            }
            
            _currentSelectedButton = null;
            timer.ResetTimer();
            timer.StartTimer();
        }
        
        private void OnAnswerSelected(AnswerButton button)
        {
            if (button == _currentSelectedButton) return;

            if (_currentSelectedButton != null)
                _currentSelectedButton.Deselect();

            _currentSelectedButton = button;
        }
    }
}