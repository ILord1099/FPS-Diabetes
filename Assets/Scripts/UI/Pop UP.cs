using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class PopUpManager : MonoBehaviour
{
    public Transform popUpTransform; // Refer�ncia ao Transform do pop-up
    public Button triggerButton; // Refer�ncia ao bot�o que aciona o pop-up
    public float duration = 0.5f; // Dura��o da anima��o

    private Vector3 hiddenScale = new Vector3(0, 0, 0); // Escala inicial do pop-up (escondido)
    private Vector3 shownScale = new Vector3(6, 6, 0); // Escala final do pop-up (vis�vel)

    void Start()
    {

        // Configurar o bot�o para chamar o m�todo ShowPopUp ao ser clicado
        triggerButton.onClick.AddListener(ShowPopUp);

        // Inicialmente, esconder o pop-up
        popUpTransform.localScale = hiddenScale;
    }

    void ShowPopUp()
    {
        // Anima o pop-up para a escala vis�vel
        popUpTransform.DOScale(shownScale, duration).SetEase(Ease.OutBack);
    }

    // Opcional: M�todo para esconder o pop-up
    public void HidePopUp()
    {
        // Anima o pop-up de volta para a escala escondida
        popUpTransform.DOScale(hiddenScale, duration).SetEase(Ease.InBack);
    }


}

