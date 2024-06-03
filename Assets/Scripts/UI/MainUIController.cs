using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Platformer.UI
{
    /// <summary>
    /// A simple controller for switching between UI panels.
    /// </summary>
    public class MainUIController : MonoBehaviour
    {
        private Coroutine idleCoroutine;
        private bool isIdle = false;
        public UnityEngine.Transform logoTransform;
        public float minScale = 9f; // Escala mínima desejada
        public float maxScale = 10f; // Escala máxima desejada
        public float duration = 0.5f;
        public float idleTime = 5.0f;
        public GameObject[] panels;
        public Vector3 tickScale = new Vector3(10f, 10f, 0f); // Escala do "tick"
        private Vector3 originalScale = new Vector3(3f, 3f, 3f);
        private int segundos = 0;

        void Start ()
        {

            //originalScale = logoTransform.localScale;
            Debug.Log(logoTransform);

            // Iniciar a coroutine de verificação de interação
            
            StartIdleCoroutine();
            RestoreAfterDelay();

        }



        public void SetActivePanel(int index)
        {
            for (var i = 0; i < panels.Length; i++)
            {
                var active = i == index;
                var g = panels[i];
                if (g.activeSelf != active) g.SetActive(active);
            }
        }

        void OnEnable()
        {
            SetActivePanel(0);
        }
        void StartIdleCoroutine()
        {
            idleCoroutine = StartCoroutine(IdleCheck());
        }

        IEnumerator IdleCheck()
        {
            while (true)
            {
                isIdle = true;
                yield return new WaitForSeconds(5f);


                if (isIdle)
                {
                    // Iniciar a animação de "tick" após o tempo ocioso
                    AnimateTick();
                }
            }
        }
        void AnimateTick()
        {
            // Anima a escala do logo para tickScale e de volta para a escala original
            logoTransform.DOScale(5, duration).OnComplete(BackAnim);

        }
        void BackAnim()
        {
            logoTransform.DOScale(originalScale, 1f).OnComplete(StartRestoreCoroutine);
        }
        void StartRestoreCoroutine()
        {
            StartCoroutine(RestoreAfterDelay());
        }
        // Nova coroutine para restaurar após 5 segundos de inatividade
        IEnumerator RestoreAfterDelay()
        {
            yield return new WaitForSeconds(segundos); // Esperar 2 segundos
            RestoreToOriginalState(); // Restaurar para o estado original
            segundos = segundos + 1;
            //Debug.Log(segundos);
        }
        void RestoreToOriginalState()
        {
            logoTransform.DOKill(); // Parar qualquer animação em andamento
            logoTransform.localScale = originalScale; // Redefinir a escala para a original
        }

        
      


    }



}