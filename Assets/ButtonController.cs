using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class ButtonController : MonoBehaviour
{
    public CanvasGroup Fade;
    public string nextSceneName;
 


    void Start()
    {
        // Adiciona um listener para o evento de clique do bot�o
        GetComponent<Button>().onClick.AddListener(OnClick);  
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



}
