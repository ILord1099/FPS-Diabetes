
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class DialogueControl : MonoBehaviour
{
    public enum idioma
    {
        pt,
        eng,
        spa
    }
    public idioma lingua;

    [Header("Components")]// boa pratica para criar um cabeçalho 
    public GameObject dialogueObj;// janela do dialogo 
    public Image profileSprite;//foto de perfil
    public Text speechText;//texto da fala 
    public Text actorNameText;//nome do npc


    [Header("Settings")]
    public float typingSpeed;// velocidade de fala 

    //variaveis de controle 
    private bool isShowing;// se a janela esta visivel
    private int index;// index é usado para laços de repetição/index das sentenças, contagem de itens/texto dentro das falas 
    private string[] sentences;// recebe todas as falas do referido npc
    
    public static DialogueControl instance; //instanciando como variavel static posso utilizar qualquer variavel e metodo que esteja publico 

    //awake é chamado antes dos starts() na hierarquita de execução de scripts
    private void Awake()
    {
        instance = this;
    }
    //chamado ao inicalizar, sendo depois do awake
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    //currotina metodo controlado por tempo.
    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())  // repete em uma array o numero de quantidade de elementos dentro do foreach/char armazena um caractere
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);//controlar o tempo da velocidade de leitura das letras expostas pelo dialogo
        }
    }
    // pular para proxima fala/frase
    public void NextSentence()
    {
        if (speechText.text == sentences[index])//checar se a frase que apareceu, apareceu por completo e so assim pode clicar no bot?o
        {
            if (index < sentences.Length - 1)
            {
                index++;
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
    }
    // chamar a fala do npc, chamado sempre que o player entrar em contato 
    public void Speech(string[]txt)
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
        Debug.Log("Chamou.Mudarcena");
        if (index == 7)

        {
            Debug.Log("index 7 ");           
            SceneManager.LoadScene("Quiz");

        }
    }
}
