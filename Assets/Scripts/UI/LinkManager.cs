using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LinkManager : MonoBehaviour
{
    public GameObject textPrefab; // Prefab do texto
    public Transform content;     // O content do Scroll View

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
        Application.OpenURL("https://www.youtube.com/watch?v=JDDxo7lcckI&list=PLC_GuOiNYmDkHjGBQSsdwADALp4lgBhdC&index=4"); // Abre o link no navegador
    }
}
