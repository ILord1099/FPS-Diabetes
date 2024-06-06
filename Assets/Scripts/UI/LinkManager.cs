using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LinkManager : MonoBehaviour
{
    public GameObject textPrefab; // Prefab do texto
    public Transform content;     // O content do Scroll View
    public LinkManager linkManager;

    void Start()
    {
        linkManager.AddLink("Example", "https://dotween.demigiant.com/documentation.php#coroutines");
        linkManager.AddLink("Unity", "https://chatgpt.com/c/73e0b907-5a12-433f-be4b-b41718d01d98");
        // Adicione quantos links quiser
    }

    public void AddLink(string linkText, string url)
    {
        GameObject newText = Instantiate(textPrefab, content);
        newText.GetComponent<Text>().text = linkText;

        // Adicionar o evento de clique
        EventTrigger trigger = newText.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { OpenLink(url); });
        trigger.triggers.Add(entry);
    }

    public void OpenLink(string url)
    {
        Application.OpenURL(url); // Abre o link no navegador
    }
}
