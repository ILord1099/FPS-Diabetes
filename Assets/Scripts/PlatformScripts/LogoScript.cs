using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScript : MonoBehaviour
{
    private Tween movementTween;
    private Vector3 originalPosition;
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
