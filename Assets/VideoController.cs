using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button yourButton;

    void Start()
    {
        // Adiciona um listener para detectar quando o v�deo termina
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Ativa o bot�o quando o v�deo termina
        yourButton.gameObject.SetActive(true);
    }

    public void PlayVideo()
    {
        // Inicia a reprodu��o do v�deo
        videoPlayer.Play();
    }
}
