using System.Collections;
using System.Collections.Generic;
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
   
}
