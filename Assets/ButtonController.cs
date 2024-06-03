using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class ButtonController : MonoBehaviour
{
    public CanvasGroup Fade;
    public string nextSceneName;
    public Transform popUpTransform; // Refer�ncia ao Transform do pop-up
    public Button triggerButton; // Refer�ncia ao bot�o que aciona o pop-up
    public float duration = 0.5f; // Dura��o da anima��o

    private Vector3 hiddenScale = new Vector3(0, 0, 0); // Escala inicial do pop-up (escondido)
    private Vector3 shownScale = new Vector3(6, 6, 0); // Escala final do pop-up (vis�vel)

    void Start()
    {
        // Adiciona um listener para o evento de clique do bot�o
        GetComponent<Button>().onClick.AddListener(OnClick);

        // Configurar o bot�o para chamar o m�todo ShowPopUp ao ser clicado
        triggerButton.onClick.AddListener(ShowPopUp);

        // Inicialmente, esconder o pop-up
        popUpTransform.localScale = hiddenScale;
    }

    void OnClick()
    {
        // Carrega a pr�xima cena quando o bot�o � clicado
        SceneManager.LoadScene(nextSceneName);
    }

    public void FadeButton()
    {
        Fade.alpha = 0f;
        Fade.DOFade(1, 0.5f);
        

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
