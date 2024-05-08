using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName =  "New Dialogue", menuName ="New dialogue/ Dialogue")] 
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]//cria�� de cabe�alho "titulo de se��o de variavel "
    public GameObject actor;// referencia o npc que voce quer que exiba o dialogo( n�o sera utilizado no momento ) 

    [Header("Dialogue")]
    public Sprite speakerSprite;// seleciona a sprite do falante do dialogo
    public string sentence;// a fala

    public List<Sentences> dialogues = new List<Sentences>();
}
//sempre serializar, pois n�o ir� aparecer no inspector 
[System.Serializable]//responsavel por serializar as classes adicionais 
public class Sentences
{
    public string actorName;// caso npc tenha nome 
    public Sprite profile;
    public Languages sentence;
}
[System.Serializable]//responsavel por serializar as classes adicionais 
public class Languages
{
    public string Portugues;
    //public string ingles;
    //public string espanhol;
}
//if chamado apenas quando a unity atende uma determinada condi��o para determinada plataforma ou interface

#if UNITY_EDITOR

#endif