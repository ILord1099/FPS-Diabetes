using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueControl : MonoBehaviour
{
    [Header("Components")]// boa pratica para criar um cabe�alho 
    public GameObject dialogueObj;// janela do dialogo 
    public Image profileSprite;//foto de perfil
    public Text speechText;//texto da fala 
    public Text actorNameText;//nome do npc


    [Header("Settings")]
    public float typingSpeed;// velocidade de fala 

    //variaveis de controle 
    private bool isShowing;// se a janela esta visivel
    private int index;// index � usado para la�os de repeti��o/index das senten�as, contagem de itens/texto dentro das falas 
    private string[] sentences;// recebe todas as falas do referido npc
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
}
