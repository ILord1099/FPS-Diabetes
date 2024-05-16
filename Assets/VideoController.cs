using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button yourButton;

    void Start()
    {
        // Adiciona um listener para detectar quando o vídeo termina
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Ativa o botão quando o vídeo termina
        yourButton.gameObject.SetActive(true);
    }

    public void PlayVideo()
    {
        // Inicia a reprodução do vídeo
        videoPlayer.Play();
    }
}
