using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogueControl : MonoBehaviour
{
    public Transform _punch;

    public enum idioma
    {
        pt,
        eng,
        spa
    }

    public idioma lingua;

    [Header("Components")] // boa pratica para criar um cabe�alho 
    public GameObject dialogueObj; // janela do dialogo 

    public Image profileSprite; //foto de perfil
    public TextMeshProUGUI speechText; //texto da fala 
    public Text actorNameText; //nome do npc
    public Button nextButton; // bot�o para a pr�xima fala
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
    public Image Mentor;
    public Image Paciente;
    public Image Aluno;
    public string proximaCena;
    [SerializeField] private DialogueSettings dialogueSettings;


    [Header("Settings")] public float typingSpeed; // velocidade de fala 

    //variaveis de controle 
    private bool isShowing; // se a janela esta visivel

    private int
        index; // index � usado para la�os de repeti��o/index das senten�as, contagem de itens/texto dentro das falas 

    private string[] sentences; // recebe todas as falas do referido npc
    private bool dialogueInProgress = false;


    public static DialogueControl
        instance; //instanciando como variavel static posso utilizar qualquer variavel e metodo que esteja publico 

    //awake � chamado antes dos starts() na hierarquita de execu��o de scripts
    private void Awake()
    {
        instance = this;
    }

    //chamado ao inicalizar, sendo depois do awake
    void Start()
    {
        var mentor = dialogueSettings.dialogues[0].actorName == "Mentor" ? Color.white : Color.black;
        var aluno = dialogueSettings.dialogues[0].actorName == "Aluno" ? Color.white : Color.black;
        var paciente = dialogueSettings.dialogues[0].actorName == "Paciente" ? Color.white : Color.black;
        Mentor.DOColor(mentor, 0f);
        Aluno.DOColor(aluno, 0f);
        Paciente.DOColor(paciente, 0f);
        AvatarFade();
        // Adicionar listener ao bot�o para chamar a fun��o Punch e NextSentence
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(OnNextButtonClick);
        }
    }

    void Update()
    {
        //Debug.Log(proximaCena);
    }

    private void OnNextButtonClick()
    {
        if (!dialogueInProgress)
        {
            Punch(); // Chama a fun��o Punch
            NextSentence(); // Avan�a para a pr�xima senten�a do di�logo
        }
    }

    //currotina metodo controlado por tempo.
    IEnumerator TypeSentence()
    {
        dialogueInProgress = true; // Indica que o di�logo est� em andamento
        nextButton.interactable = false; // Desativa o bot�o enquanto a senten�a est� sendo exibida
        foreach (char letter in
                 sentences[index]
                     .ToCharArray()) // repete em uma array o numero de quantidade de elementos dentro do foreach/char armazena um caractere
        {
            speechText.text += letter;
            yield return
                new WaitForSeconds(
                    typingSpeed); //controlar o tempo da velocidade de leitura das letras expostas pelo dialogo
        }

        dialogueInProgress = false; // Indica que o di�logo terminou
        nextButton.interactable = true; // Ativa o bot�o novamente
    }

    // pular para proxima fala/frase
    public void NextSentence()
    {
        if (speechText.text ==
            sentences[index]) //checar se a frase que apareceu, apareceu por completo e so assim pode clicar no bot?o
        {
            if (index < sentences.Length - 1)
            {
                index++;
                Debug.Log(index);
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else // quando termina os textos 
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }

            Debug.Log(index);
        }

        MudarCena();
        ChangeColor();
    }

    // chamar a fala do npc, chamado sempre que o player entrar em contato 
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }

    public void MudarCena()
    {
        if (index == 8)

        {
            proximaCena = proximaCena;
            Debug.Log(proximaCena);
            //Debug.Log("index 8 ");
            SceneManager.LoadScene(proximaCena);
            // index = 9;
        }
    }

    public void Punch()
    {
        var duration = 0.5f;
        _punch.DOPunchPosition(
            punch: Vector3.right * 2,
            duration: duration,
            vibrato: 0,
            elasticity: 0);
    }

    public void AvatarFade()
    {
        canvasGroup.alpha = 0f;
        // rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        canvasGroup.DOFade(1, 1f);
    }

    public void ChangeColor()
    {
        if (index == 1)
        {
            //Mentor On

            Mentor.DOColor(Color.black, 1f);
            Aluno.DOColor(Color.black, 1f);
            Paciente.DOColor(Color.white, 1f);
        }

        if (index == 2)
        {
            //Paciente On

            Aluno.DOColor(Color.white, 1f);
            Paciente.DOColor(Color.black, 1f);
        }

        if (index == 3)
        {
            //Aluno On

            Aluno.DOColor(Color.black, 1f);
            Paciente.DOColor(Color.white, 1f);
        }

        if (index == 4)
        {
            //Mentor On

            Mentor.DOColor(Color.white, 1f);
            Aluno.DOColor(Color.black, 1f);
            Paciente.DOColor(Color.black, 1f);
        }

        if (index == 5)
        {
            //alunoOn
            Mentor.DOColor(Color.black, 1f);
            Aluno.DOColor(Color.white, 1f);
        }

        if (index == 6)
        {
            //Mentor on
            Mentor.DOColor(Color.white, 1f);
            Aluno.DOColor(Color.black, 1f);
        }

        if (index == 7)
        {
            //aluno On
            Mentor.DOColor(Color.black, 1f);
            Aluno.DOColor(Color.white, 1f);
        }
    }
}