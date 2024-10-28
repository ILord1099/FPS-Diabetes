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
    public LayerMask layer;
    public Vector2 dir;
    public Transform groundPivot;
    public bool isGrounded;
    public float DetectionGround;
    public SpriteRenderer sr;

    public Animator anim;
    private bool isJumping;
    private bool doubleJump;
    public string sceneName;
    private int AuxDirecao;
    int jumpCount = 0;
    public int maxJumps = 2;





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
        dir.x = Input.GetAxisRaw("Horizontal") * speed;
        dir.y = rig.velocity.y;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sr.flipX = true;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sr.flipX = false;
        }

    }
    void FixedUpdate()
    {

        rig.velocity = dir;

        //move();
        /*if (AuxDirecao != 0)
        {
            transform.Translate(speed * Time.deltaTime * AuxDirecao, 0, 0);
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
            }
        }

        if (AuxDirecao > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetInteger("Transition", 1);
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);

            }
        }
        if (AuxDirecao < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetInteger("Transition", 1);
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);

            }
        }*/
    }
    #region Movimentação
    /*void move()
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
    }*/
    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundPivot.position, DetectionGround, layer);

        // Reseta o contador de pulos quando o jogador está no chão
        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Verifica se o jogador pode pular (no chão ou pulo duplo)
        if ((isGrounded || jumpCount < maxJumps) && Input.GetKeyDown(KeyCode.Space))
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            jumpCount++; // Incrementa o contador de pulos
        }

        // Depuração: exibir no console o estado de isGrounded
        Debug.Log("Está no chão: " + isGrounded);
        /*if(Input.GetKeyDown(KeyCode.Space))
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

        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPivot.position, DetectionGround);
    }
    public bool IsGrounded { get { return isGrounded; } }
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

        if (colisor.gameObject.CompareTag("Plataform UP"))
        {
            transform.parent = colisor.transform;
        }
    }

    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(0.2f); // 1 second delay
        GameController.instance.Dead();
       
    }
    #endregion

    public void TouchHorizontal(int direcao)
    {
        AuxDirecao = direcao;
    }

    public void Pular()
    {
        if (!isJumping)
        {
            anim.SetInteger("Transition", 2);
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            doubleJump = true;
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
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataform UP"))
        {
            transform.parent = null;
        }
    }
}