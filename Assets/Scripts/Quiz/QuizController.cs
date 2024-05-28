using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Quiz
{
    public class QuizController : MonoBehaviour
    {
        [SerializeField] private Form form;
        [SerializeField] private QuizView quizView;
        [SerializeField] private string sceneToLoad;

        private int _currentQuestionIndex = 0;

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
        }

        private void EndTimeQuestion()
        {
            _currentQuestionIndex++;

            if (_currentQuestionIndex == form.GetQuestionsCount())
            {

                StartSceneTransition();
                return;
            }

            var question = form.GetQuestion(_currentQuestionIndex);
            quizView.SetQuestion(question.question);
            quizView.SetAnswers(question.answers);
        }
        public void StartSceneTransition()
        {
            StartCoroutine(LoadSceneAfterDelay());
        }
        private IEnumerator LoadSceneAfterDelay()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}