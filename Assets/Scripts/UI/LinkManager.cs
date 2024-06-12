using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LinkManager : MonoBehaviour
{
    public void OpenLink(string url)
    {
        Application.OpenURL(url); // Abre o link no navegador
    }
}
