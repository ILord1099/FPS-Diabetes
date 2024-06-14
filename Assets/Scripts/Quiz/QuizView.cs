using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Quiz
{
    public class QuizView : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private List<AnswerButton> answerButtons;
        [SerializeField] private TMP_Text questionText;
        public Transform popUpTransform;
        public Transform popUpErrorTransform;
        public float duration = 0.5f;
        [SerializeField] private sound soundButtons;

        private AnswerButton _currentSelectedButton;

        public event Action OnEndTimeQuestion;

        private void Start()
        {
            popUpTransform.localScale = Vector3.zero;
        }

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
            }

            OnEndTimeQuestion?.Invoke();
        }
        
        public AnswerButton SelectedAnswer => _currentSelectedButton;

        public void SetQuestion(string question) => questionText.text = question;

        public void SetAnswers(List<Answer> answers)
        {
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
            soundButtons.PlaySFX(soundButtons.selectSound);
            if (button == _currentSelectedButton) return;

            if (_currentSelectedButton != null)
                _currentSelectedButton.Deselect();

            _currentSelectedButton = button;
        }

        public void ShowPopUp()
        {
            // Anima o pop-up para a escala vis�vel
            popUpTransform.DOScale(new Vector3(12, 8, 0), duration).SetEase(Ease.InBack);
        }
        
        public void ShowPopUpError()
        {
            // Anima o pop-up para a escala vis�vel
            popUpErrorTransform.DOScale(new Vector3(12, 8, 0), duration).SetEase(Ease.InBack);
        }

        public void HidePopUp()
        {
            // Anima o pop-up de volta para a escala escondida
            popUpTransform.DOScale(Vector3.zero, duration).SetEase(Ease.OutBack);
        }
        
        public void HidePopUpError()
        {
            // Anima o pop-up de volta para a escala escondida
            popUpErrorTransform.DOScale(Vector3.zero, duration).SetEase(Ease.OutBack);
        }
    }
}