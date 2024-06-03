using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class ButtonController : MonoBehaviour
{
    public CanvasGroup Fade;
    public string nextSceneName;
    public Transform popUpTransform; // Referência ao Transform do pop-up
    public Button triggerButton; // Referência ao botão que aciona o pop-up
    public float duration = 0.5f; // Duração da animação

    private Vector3 hiddenScale = new Vector3(0, 0, 0); // Escala inicial do pop-up (escondido)
    private Vector3 shownScale = new Vector3(6, 6, 0); // Escala final do pop-up (visível)

    void Start()
    {
        // Adiciona um listener para o evento de clique do botão
        GetComponent<Button>().onClick.AddListener(OnClick);

        // Configurar o botão para chamar o método ShowPopUp ao ser clicado
        triggerButton.onClick.AddListener(ShowPopUp);

        // Inicialmente, esconder o pop-up
        popUpTransform.localScale = hiddenScale;
    }

    void OnClick()
    {
        // Carrega a próxima cena quando o botão é clicado
        SceneManager.LoadScene(nextSceneName);
    }

    public void FadeButton()
    {
        Fade.alpha = 0f;
        Fade.DOFade(1, 0.5f);
        

    }

    void ShowPopUp()
    {
        // Anima o pop-up para a escala visível
        popUpTransform.DOScale(shownScale, duration).SetEase(Ease.OutBack);
    }

    // Opcional: Método para esconder o pop-up
    public void HidePopUp()
    {
        // Anima o pop-up de volta para a escala escondida
        popUpTransform.DOScale(hiddenScale, duration).SetEase(Ease.InBack);
    }


}
