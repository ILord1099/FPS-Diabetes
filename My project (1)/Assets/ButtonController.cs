using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
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
}
