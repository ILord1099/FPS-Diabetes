using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position,dialogueRange,playerLayer);

        if (hit != null )
        {
            Debug.Log("Player na area de colis�o ");
        }
        else
        {

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,dialogueRange);
    }
}
