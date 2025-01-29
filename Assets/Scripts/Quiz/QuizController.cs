using System;
using System.Collections;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Quiz
{
    public class QuizController : MonoBehaviour
    {
        [SerializeField] private Form form;
        [SerializeField] private QuizView quizView;
        [SerializeField] private string sceneToLoad;
        [SerializeField] private sound soundButtons;
        [SerializeField] private Points points;

        private int _currentQuestionIndex = 0;

        private void Awake()
        {
            points = Resources.Load<Points>("points");
        }

        private void OnEnable()
        {
            quizView.OnEndTimeQuestion += EndTimeQuestion;
        }

        private void OnDisable()
        {
            quizView.OnEndTimeQuestion -= EndTimeQuestion;
        }

        private void Start()
        {
            _currentQuestionIndex = 0;
            var question = form.GetQuestion(_currentQuestionIndex);
            quizView.SetQuestion(question.question);
            quizView.SetAnswers(question.answers);
            points.AddTotalPoints(form.GetQuestionsCount());
        }

        private void EndTimeQuestion()
        {
            _currentQuestionIndex++;

            if (quizView.SelectedAnswer && quizView.SelectedAnswer.IsCorrect)
            {
                points.AddCurrentPoints(1);
                quizView.SelectedAnswer.CorrectAnim();
                soundButtons.PlaySFX(soundButtons.correctSound);
                quizView.ShowPopUp();
                return;
            }

            if (quizView.SelectedAnswer)
                quizView.SelectedAnswer.IncorrectAnim();
            soundButtons.PlaySFX(soundButtons.incorrectSound);
            quizView.ShowPopUpError();
        }

        public void NextQuestion()
        {
            if (_currentQuestionIndex == form.GetQuestionsCount())
            {
                Debug.LogWarning($"Você acertou {points.CorrectAnswers} de {points.TotalQuestions}");
                // Salvar os pontos antes de carregar a próxima cena
                PlayerPrefs.SetInt("CorrectAnswers", points.CorrectAnswers);
                PlayerPrefs.SetInt("TotalQuestions", points.TotalQuestions);
                PlayerPrefs.Save();
                StartCoroutine(LoadScene());
                return;
            }

            var question = form.GetQuestion(_currentQuestionIndex);
            quizView.SetQuestion(question.question);
            quizView.SetAnswers(question.answers);
        }

        IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(1.4f);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
