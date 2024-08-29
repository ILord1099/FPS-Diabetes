using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Quiz
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float seconds = 60f;
        [SerializeField] private TMP_Text timerText;
        private Coroutine _timerCoroutine;

        private float _timeLeft;
        private Color _defaultColor;

        public event Action OnStart;
        public event Action OnEnd;

        private void Start()
        {
            _defaultColor = timerText.color;
            _timeLeft = seconds;
            timerText.text = GetFormatTime();
        }

        public void ResetTimer()
        {
            StopAllCoroutines();
            _timeLeft = seconds;
            timerText.text = GetFormatTime();
        }

        public void StartTimer()
        {
            if (_timerCoroutine != null)
                StopCoroutine(_timerCoroutine);
            
            _timerCoroutine = StartCoroutine(TimerCoroutine());
        }

        public void StopTimer()
        {
            if (_timerCoroutine == null) return;
            StopCoroutine(_timerCoroutine);
            OnEnd?.Invoke();
            _timerCoroutine = null;
        }

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForEndOfFrame();
            OnStart?.Invoke();
            
            while (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                //show the time in the format 00:00
                timerText.text = GetFormatTime();
                timerText.color = _timeLeft < 10 ? Color.red : _defaultColor;
                yield return null;
            }

            OnEnd?.Invoke();
            _timerCoroutine = null;
        }

        private string GetFormatTime() => $"{(int)_timeLeft / 60:00}:{(int)_timeLeft % 60:00}";
    }
}