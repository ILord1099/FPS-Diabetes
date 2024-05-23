using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformup : MonoBehaviour
{
    public float speed;
    public float moveTime;

    
    public bool upMove;
    private float timer;

    public void Update()
    {
        MoveUp();
    }
    void MoveUp()
    {
        {

            if (upMove)
            {
                upMove = true;
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                upMove = false;
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
            timer += Time.deltaTime;
            if (timer > moveTime)
            {
                upMove = !upMove;
                timer = 0f;
            }
        }
    }
}
