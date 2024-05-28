using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class ButtonController : MonoBehaviour
{
    public RectTransform _Rect;
    public CanvasGroup _fade;
    public string nextSceneName;

    void Start()
    {
        // Adiciona um listener para o evento de clique do botão
        GetComponent<Button>().onClick.AddListener(OnClick);
    
    }

    void OnClick()
    {
        // Carrega a próxima cena quando o botão é clicado
        SceneManager.LoadScene(nextSceneName);
    }

    public void Fade()
    {
        _fade.alpha = 0f;
        _Rect.transform.localPosition = new Vector3(15.38428f, 9.252686f, 0f);
        _Rect.DOAnchorPos(new Vector2(15.38428f, 9.252686f), 1.6f, false);
        _fade.DOFade(1, 1f);
    }

}
