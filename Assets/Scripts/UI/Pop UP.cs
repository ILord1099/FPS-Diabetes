using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

using JetBrains.Annotations;
public class PopUpManager : MonoBehaviour
{
    public Transform popUpTransform; // Referência ao Transform do pop-up
    public Button triggerButton; // Referência ao botão que aciona o pop-up
    public float duration = 0.5f; // Duração da animação
    public Image imageToControl;

    private Vector3 hiddenScale = new Vector3(0, 0, 0); // Escala inicial do pop-up (escondido)
    private Vector3 shownScale = new Vector3(12,8 , 0); // Escala final do pop-up (visível)

    void Start()
    {

        // Configurar o botão para chamar o método ShowPopUp ao ser clicado
        triggerButton.onClick.AddListener(ShowPopUp);

        // Inicialmente, esconder o pop-up
        popUpTransform.localScale = hiddenScale;
    }

    void ShowPopUp()
    {
        // Anima o pop-up para a escala visível
        popUpTransform.DOScale(shownScale, duration).SetEase(Ease.OutBack);
        DisableImage();
    }

    // Opcional: Método para esconder o pop-up
    public void HidePopUp()
    {
        // Anima o pop-up de volta para a escala escondida
        popUpTransform.DOScale(hiddenScale, duration).SetEase(Ease.InBack);
        StartDelayedAction();
        EnableImage();
    }

    // Função para desativar a imagem
    public void DisableImage()
    {
        if (imageToControl != null)
        {
            imageToControl.enabled = false;
        }
    }

    // Função para ativar a imagem
    public void EnableImage()
    {
        if (imageToControl != null)
        {
            imageToControl.enabled = true;
        }
    }

    public void StartDelayedAction()
    {
        StartCoroutine(DelayedAction(3.0f)); // Espera 3 segundos antes de executar a ação
    }

    private IEnumerator DelayedAction(float delay)
    {
        yield return new WaitForSeconds(delay); // Espera pelo tempo especificado
        
    }
}

