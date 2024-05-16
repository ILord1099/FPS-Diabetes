using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public float jumpForce;
    private bool isJumping;
    private bool doubleJump;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Jump();
    }
    void FixedUpdate()
    {
        move();
    }
    #region Movimentação
    void move()
    {
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2 (movement * speed, rig.velocity.y);

        /*if (movement < 0 )
        {
            //mudança de angulo da sprite(direita) 
            transform.eulerAngles =  new Vector3(0, 0, 0);
        }
        if(movement > 0 )
        {
            //mudança de angulo da sprite(esquerda)
            transform.eulerAngles =  new Vector3(0, 180, 0);
            //ativar apenas quando inserir as sprites
        }*/
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           if (!isJumping) 
            {   
                
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
                doubleJump =  true;
            }
           else if (doubleJump) 
            {
                //
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                doubleJump = false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.layer ==  8)
        {
            isJumping=false;
        }
    }
    #endregion
}