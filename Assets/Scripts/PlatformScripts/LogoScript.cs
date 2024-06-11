using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScript : MonoBehaviour
{
     void Start()
    {
        transform.DOLocalMoveY(-1f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called with: ");
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Collect()
    {
        // Adicione a lógica para o que acontece quando o objeto é coletado
        Debug.Log("Item Coletado!");
        Destroy(gameObject);
    }
}
