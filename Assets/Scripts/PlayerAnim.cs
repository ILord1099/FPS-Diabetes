using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField]
    private Animator Anim;
    [SerializeField]
    private Rigidbody2D rig;
    [SerializeField]
    private Player Player;


    private void Update()
    {
        if (this.Player.IsGrounded)
        {
            float velocidadeX = Mathf.Abs(this.rig.velocity.x);
            if (velocidadeX > 0)
            {
                this.Anim.SetBool("Correndo", true);

            }
            else
            {
                this.Anim.SetBool("Correndo", false);
            }
            this.Anim.SetBool("Pulando", false);
            this.Anim.SetBool("Caindo", false);
        }
        else
        {
            float velocidadeY = this.rig.velocity.y;
            if (velocidadeY > 0)
            {
                this.Anim.SetBool("Pulando", true);
                this.Anim.SetBool("Caindo", false);
            }
            else if (velocidadeY < 0)
            {
                this.Anim.SetBool("Pulando", false);
                this.Anim.SetBool("Caindo", true);
            }
        }

    }
}
