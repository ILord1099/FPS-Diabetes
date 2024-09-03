using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button yourButton;
    public string videoName;
    public Button Button2x;
    public Button Button1x;
    public Button Button3x;
    public Button advanceButton; 
    public Button rewindButton;
    public float skipTime = 10f;
    public Button PauseButton;
    public Button PlayButton;





    void Start()
    {
        var videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
        videoPlayer.url = videoPath;
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;

        advanceButton.onClick.AddListener(AdvanceVideo);
        rewindButton.onClick.AddListener(RewindVideo);
    }


    void EndReached(VideoPlayer vp)
    {
        // Ativa o bot�o quando o v�deo termina
        yourButton.gameObject.SetActive(true);

    }

    public void PlayVideo()
    {
        // Inicia a reprodu��o do v�deo
        videoPlayer.Play();
        

    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
        PlayButton.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(false);
    }

    public void Acelerador()
    {
        videoPlayer.playbackSpeed = 1.5f;
        Button2x.gameObject.SetActive(false);
        Button3x.gameObject.SetActive(true);
    }
    public void NormalSpeed()
    {
        videoPlayer.playbackSpeed = 1;
        Button1x.gameObject.SetActive(false);
        Button2x.gameObject.SetActive(true);
        Button3x.gameObject.SetActive(false);
    }
    public void Acelerador2()
    {
        videoPlayer.playbackSpeed = 2;
        Button1x.gameObject.SetActive(true);
        Button3x.gameObject.SetActive(false);
    }
    public void AdvanceVideo()
    {
        // Avança o vídeo em 'skipTime' segundos
        if (videoPlayer.isPrepared)
        {
            videoPlayer.time += skipTime;

            // Impede que o tempo avance além da duração do vídeo
            if (videoPlayer.time > videoPlayer.length)
            {
                videoPlayer.time = videoPlayer.length;
            }
        }
    }

    public void RewindVideo()
    {
        // Retrocede o vídeo em 'skipTime' segundos
        if (videoPlayer.isPrepared)
        {
            videoPlayer.time -= skipTime;

            // Impede que o tempo retroceda além do início do vídeo
            if (videoPlayer.time < 0)
            {
                videoPlayer.time = 0;
            }
        }
    }


}
