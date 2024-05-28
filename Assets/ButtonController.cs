using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class ButtonController : MonoBehaviour
{
    public Transform _punch;
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
