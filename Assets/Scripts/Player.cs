using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public float jumpForce;
    private sound playerAudio;

    public Animator anim;
    private bool isJumping;
    private bool doubleJump;
    public string sceneName;




    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<sound>();

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

        if (movement > 0 )

        {
            //playerAudio.PlaySFX(playerAudio.walkSound);
            //mudança de angulo da sprite(direita) 
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);

            }
            transform.eulerAngles = new Vector3 (0, 0, 0);
        }
        if(movement < 0 )
        {
          //  playerAudio.PlaySFX(playerAudio.walkSound);
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
            }
            //mudança de angulo da sprite(esquerda)
            transform.eulerAngles =  new Vector3(0, 180, 0);
            //ativar apenas quando inserir as sprites
        }
        if (movement ==  0 && !isJumping)
        {
            anim.SetInteger("Transition", 0 );
        }
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           if (!isJumping) 
            {
                anim.SetInteger("Transition", 2);
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
                doubleJump =  true;
                playerAudio.PlaySFX(playerAudio.jumpSound);
            }
           else if (doubleJump) 
            {
                //
                anim.SetInteger("Transition", 2);
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                doubleJump = false;
                playerAudio.PlaySFX(playerAudio.jumpSound);
            }

        }
    }
    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.layer ==  8)
        {
            isJumping=false;
        }
        if (colisor.gameObject.layer == 12)
        {
            GameController.instance.NextLVL();
        }

        if (colisor.gameObject.layer == 9)
        { 
            playerAudio.PlaySFX(playerAudio.deadSound);
            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(0.2f); // 1 second delay
        GameController.instance.Dead();
       
    }
    #endregion
}