using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlataformMoveUp : MonoBehaviour
{
    public float speed;
    public float moveTime;

    public bool dirRight;
    private float timer;
    // Update is called once per frame
    void Update()
    {

        MoveRight();
       
    }
    void MoveRight()

    {
       

       if (dirRight)
            {
                dirRight = true;
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
       else
            {
                dirRight = false;
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
             timer += Time.deltaTime;
       if (timer > moveTime)
         {
                dirRight = !dirRight;
                timer = 0f;
         }
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

}
