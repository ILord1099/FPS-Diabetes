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
    

   

    void Start()
    {
        var videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
        videoPlayer.url = videoPath;
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;

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



}
