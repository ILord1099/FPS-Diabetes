using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class ExibirTempoVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Refer�ncia ao componente VideoPlayer
    public TMP_Text textoTempo; // Refer�ncia ao elemento de Texto UI
    //public Slider barraProgresso; // Refer�ncia ao elemento de Slider UI

    void Start()
    {
        // Configurar a barra de progresso com a dura��o total do v�deo
        //barraProgresso.maxValue = (float)videoPlayer.length;

    }
    void Update()
    {
       
        // Obter o tempo atual do v�deo em segundos
        double tempoAtual = videoPlayer.time;
        double duracaoTotal = videoPlayer.length;
        double tempoRestante = duracaoTotal - tempoAtual;
        // Formatar o tempo para minutos e segundos
        string minutosAtuais = Mathf.Floor((float)tempoAtual / 60).ToString("00");
        string segundosAtuais = Mathf.Floor((float)tempoAtual % 60).ToString("00");
        string minutosRestantes = Mathf.Floor((float)tempoRestante / 60).ToString("00");
        string segundosRestantes = Mathf.Floor((float)tempoRestante % 60).ToString("00");


        // Atualizar o Texto UI com o tempo atual e o tempo restante formatados
        textoTempo.text = string.Format("{0}:{1} / {2}:{3}", minutosAtuais, segundosAtuais, minutosRestantes, segundosRestantes);

        // Atualizar a barra de progresso
        //barraProgresso.value = (float)tempoAtual;
    }
}
