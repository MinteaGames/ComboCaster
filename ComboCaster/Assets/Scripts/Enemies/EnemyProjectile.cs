using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Animator animator;

    public float speed = 15;

    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;

    // Start is called before the first frame update
    void Start()
    {

        print("spawned");
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);

        animator.SetBool("HasHit", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {

        }
        else if (other.name == "Detection")
        {

        }
        else
        {
            animator.SetBool("HasHit", true);
        }
    }


    //void modifyDamage(float modifier)
    //{

    //    damage = damage * modifier;

    //}
}
