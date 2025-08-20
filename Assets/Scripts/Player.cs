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
    private int AuxDirecao; // usado para botões
    int jumpCount = 0;
    public int maxJumps = 2;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<sound>();
    }

    void Update()
    {
        CheckJump();

        // Movimento pelo teclado
        float move = Input.GetAxisRaw("Horizontal");

        // Se não houver input do teclado, usa o valor dos botões
        if (move == 0)
            move = AuxDirecao;

        // Define a direção
        dir.x = move * speed;
        dir.y = rig.velocity.y;

        // Virar o sprite
        if (move < 0)
            sr.flipX = true;
        else if (move > 0)
            sr.flipX = false;
    }

    void FixedUpdate()
    {
        rig.velocity = dir;
    }

    #region Movimentação

    // Verifica inputs de pulo (teclado)
    void CheckJump()
    {
        // Verifica se está no chão
        isGrounded = Physics2D.OverlapCircle(groundPivot.position, DetectionGround, layer);

        // Reseta contador de pulos somente quando tocando o chão e não subindo
        if (isGrounded && rig.velocity.y <= 0.01f)
        {
            jumpCount = 0;
        }

        // Pulo com teclado
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }
    }

    // Função chamada tanto pelo teclado quanto pelo botão
    void TryJump()
    {
        if (jumpCount < maxJumps)
        {
            DoJump();
        }
    }

    // Função unificada para aplicar o pulo
    void DoJump()
    {
        // anim.SetInteger("Transition", 2); // descomente se quiser animação
        rig.velocity = new Vector2(rig.velocity.x, jumpForce);
        jumpCount++;
        playerAudio.PlaySFX(playerAudio.jumpSound);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPivot.position, DetectionGround);
    }

    public bool IsGrounded { get { return isGrounded; } }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.layer == 8)
        {
            isJumping = false;
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
        yield return new WaitForSeconds(0.2f);
        GameController.instance.Dead();
    }
    #endregion

    // ==== CONTROLES DE BOTÕES UI ====

    public void TouchHorizontal(int direcao)
    {
        AuxDirecao = direcao;
    }

    public void Soltar()
    {
        AuxDirecao = 0;
    }

    // Pulo via botão
    public void Pular()
    {
        TryJump();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataform UP"))
        {
            transform.parent = null;
        }
    }
}
