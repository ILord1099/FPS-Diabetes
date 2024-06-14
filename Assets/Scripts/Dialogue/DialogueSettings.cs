using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName =  "New Dialogue", menuName ="New dialogue/ Dialogue")] 
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]//criaçã de cabeçalho "titulo de seção de variavel "
    public GameObject actor;// referencia o npc que voce quer que exiba o dialogo( não sera utilizado no momento ) 

    [Header("Dialogue")]
    public Sprite speakerSprite;// seleciona a sprite do falante do dialogo
    public string sentence;// a fala

    public List<Sentences> dialogues = new List<Sentences>();
}
//sempre serializar, pois não irá aparecer no inspector 
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
    public string ingles;
    public string espanhol;
}
//if chamado apenas quando a unity atende uma determinada condição para determinada plataforma ou interface

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BiulderEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()//override sobreescreve algum metodo na classe herdada.
    {
        DrawDefaultInspector();

        DialogueSettings ds =  (DialogueSettings)target;// onde vai armazenar as informações/ configurações  
        Languages l = new Languages();
        l.Portugues =  ds.sentence;// armazena sentenças na lingua selecionada padronizada em portugues 

        Sentences s = new Sentences();
        s.profile =  ds.speakerSprite;// armazena foto do perfil do personagem falando 
        s.sentence = l;

        if (GUILayout.Button("Criate Dialogue"))
        {
            if (ds.sentence != "")
            {
                ds.dialogues.Add(s);

                ds.speakerSprite = null;
                ds.sentence = "";// apos criar fala, apaga fala e deixa o botão livre para criação de um novo dialogo

            }
        }
    }
}
#endif