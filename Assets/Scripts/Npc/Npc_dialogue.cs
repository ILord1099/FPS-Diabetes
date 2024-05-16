using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    public DialogueSettings dialogue;

    public bool playerHit = true;

    private List<string> sentences  =  new List<string>();// armazena aqui os dialogos e repassa pra variavel de controle 


    private void Start()
    {
        GetNPCInfo();
    }
    void Update()
    { // variavel de controle 
        if(/*Input.GetKeyDown(KeyCode.E) &&*/playerHit = true)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }
    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; ++i) // for sempre precisa de um controlador, repetir enquanto o npc tiver fala, se for uma vez vai repetir apenas uma vez.

        {
            switch (DialogueControl.instance.lingua)
            {

                case DialogueControl.idioma.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.Portugues);

                    break;
                case DialogueControl.idioma.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.ingles);

                    break;
                case DialogueControl.idioma.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.espanhol);

                    break;
            }
        }
    }
    // Update is called once per frame
    


    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position,dialogueRange,playerLayer);

        if (hit != null )
        {
          playerHit = true;
        }
        else
        {
            playerHit=false;
            DialogueControl.instance.dialogueObj.SetActive(false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,dialogueRange);
    }
}
