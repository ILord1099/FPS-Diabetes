using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AnimationLogo : MonoBehaviour
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
