using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
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
}
