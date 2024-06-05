using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    public float fallingTime;

    //private TargetJoint2D target;
    private CapsuleCollider2D boxColl;
    // Start is called before the first frame update
    void Start()
    {
        //target =  GetComponent<TargetJoint2D>();
        boxColl = GetComponent<CapsuleCollider2D>();
    }

    void OnCollisionEnter2D( Collision2D collision)
    {
        if (collision.gameObject.tag ==  "Player")
        {
            Invoke("Falling", fallingTime);
        }
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }

    }
    void Falling()
    {
        //target.enabled = false;
        boxColl.isTrigger = true;
    }
}
