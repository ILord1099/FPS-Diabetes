using DG.Tweening;
using Platformer.Mechanics;
using Quiz;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class LogoScript : MonoBehaviour
{
    private Tween movementTween;
    private Vector3 originalPosition;
    [SerializeField] public float extraTime = 10f;  // Quantidade de tempo extra que este item concede
    
    void Start()
    {
        originalPosition = transform.position;
        movementTween = transform.DOLocalMoveY(originalPosition.y -0.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Collect()
    {
        GameManager.ExtraTime += extraTime;  // Adiciona o tempo extra ao GameManager
        Destroy(gameObject);
        OnDestroy();
    }

    public Vector3 GetOriginalPosition()
    {
        return originalPosition;
    }
    void OnDestroy()
    {
        // Certificar-se de matar o tween ao destruir o objeto para evitar erros
        if (movementTween != null)
        {
            movementTween.Kill();
        }
    }


}
