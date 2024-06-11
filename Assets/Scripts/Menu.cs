using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public float fadetime = 1f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
    public List<GameObject> itens = new List<GameObject>();
    public string nomeCena;
    private List<Vector3> originalScales = new List<Vector3>();
    // Start is called before the first frame update
    public CanvasGroup Avatar;
    
    void Start()
    {

        AvatarFade();
        foreach (var item in itens)
        {
            originalScales.Add(item.transform.localScale);
        }
        PanelFadeaain();
        
    }
    public void scene_changer(string scene_name)

    {
        
        SceneManager.LoadScene(nomeCena);
    }

 

    public void PanelFadeaain()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadetime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadetime);
        StartCoroutine("ItensAnimaition");

    }
    IEnumerator ItensAnimaition()
    {
       
        foreach (var item in itens)
        {
            item.transform.localScale = Vector2.zero;
        }
        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(originalScales[i], 1f).SetEase(Ease.InCubic);
            yield return new WaitForSeconds(0.25f);
            
        }
    }

    public void AvatarFade()
    {
        Avatar.alpha = 0f;
        Avatar.DOFade(1, 3f);
    }


}