using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScript : MonoBehaviour
{
    private void Start()
    {
        LogoAnim();

    }
    public void LogoAnim()
    {
        transform.DOLocalMoveY(-1f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
