using UnityEngine;

namespace Quiz
{
    public class GameScore : MonoBehaviour
    {
        public int Score { get; private set; }

        public void AddScore(int score)
        {
            if((Score + score) < 0) return;
            Score += score;
        }
        public void ResetScore() => Score = 0;
    }
}