using Platformer.Mechanics;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Quiz
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] public float seconds = 60f;
        [SerializeField] private TMP_Text timerText;

        public static Timer instance;
        
        private float _timeLeft;
        private Color _defaultColor;
        
        public event Action OnStart;
        public event Action OnEnd;

        private void Start()
        {
            _defaultColor = timerText.color;
            _timeLeft = seconds + GameManager.ExtraTime; 
            GameManager.ExtraTime = 0;  // Reseta o tempo extra após usá-lo
            
        }
        
        public void ResetTimer() => _timeLeft = seconds;
        
        public void StartTimer() => StartCoroutine(TimerCoroutine());
        
        public void StopTimer() => StopCoroutine(TimerCoroutine());

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForEndOfFrame();
            OnStart?.Invoke();
            
            while (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                //show the time in the format 00:00
                timerText.text = $"{(int) _timeLeft / 60:00}:{(int) _timeLeft % 60:00}";
                timerText.color = _timeLeft < 10 ? Color.red : _defaultColor;
                yield return null;
            }
            
            OnEnd?.Invoke();
        }
    }
}