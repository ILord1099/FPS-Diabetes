using Quiz.Fake;
using UnityEngine;

namespace Quiz.Presenter
{
    /// <summary>
    /// link between the view and the quiz machine
    /// </summary>
    public class QuizPresenter : MonoBehaviour
    {
        [Header("Models")] [SerializeField] private QuizMachine quizMachine;

        [SerializeField] private Timer timer;

        [Header("views")] [SerializeField] private QuizView quizView;

        private void Start()
        {
            timer.ResetTimer();
            timer.StartTimer();
        }

        private void OnEnable()
        {
            ClientGeneric.OnQuestionsLoaded += SetQuestion;
            timer.OnTick += quizView.UpdateTimer;
            timer.OnEnd += EndTimer;
            quizView.OnNextQuestion += NextQuestion;
            quizView.OnMarkedAnswer += MarkedAnswer;
            quizView.SetupButtons(quizMachine.GetCorrectAnswers().Length);
        }

        private void OnDisable()
        {
            ClientGeneric.OnQuestionsLoaded -= SetQuestion;
            timer.OnTick -= quizView.UpdateTimer;
            timer.OnEnd -= EndTimer;
            quizView.OnNextQuestion -= NextQuestion;
            quizView.OnMarkedAnswer -= MarkedAnswer;
        }

        private void EndTimer()
        {
            timer.StopTimer();
            MarkedAnswer();
            Invoke(nameof(NextQuestion), 0.2f);
        }

        private void NextQuestion()
        {
            timer.StopTimer();
            quizView.Reset();
            quizMachine.NextQuestion();
            SetQuestion();
            timer.ResetTimer();
            timer.StartTimer();
        }

        private void MarkedAnswer()
        {
            foreach (var correctAnswer in quizMachine.GetCorrectAnswers())
            {
                quizView.UpdateButtonColor(correctAnswer);
            }
        }

        private void SetQuestion()
        {
            var question = quizMachine.GetCurrentQuestion();
            quizView.SetTitleQuestion(question.title);
            quizView.SetAnswers(question.options);
        }
    }
}