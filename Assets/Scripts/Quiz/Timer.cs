using System;
using System.Collections;
using UnityEngine;

namespace Quiz
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float seconds = 60f;

        private float _timeLeft;

        public event Action OnStart;

        public event Action<float> OnTick;
        public event Action OnEnd;

        private void Start() => _timeLeft = seconds;

        public void ResetTimer() => _timeLeft = seconds;

        public void StartTimer() => StartCoroutine(TimerCoroutine());

        public void StopTimer() => StopAllCoroutines();

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForEndOfFrame();
            OnStart?.Invoke();

            while (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                OnTick?.Invoke(_timeLeft);
                yield return null;
            }

            OnEnd?.Invoke();
        }
    }
}