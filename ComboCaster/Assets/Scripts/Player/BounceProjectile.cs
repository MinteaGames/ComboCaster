using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceProjectile : MonoBehaviour
{

    public Animator animator;

    public float speed = 5;

    public float damage = 1;

    public int numOfBounces = 0;

    Rigidbody2D rigidbody;


    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.AddForce(transform.up * speed);

        //animator.SetBool("HasHit", false);
    }

    void pullTowardsPlayer(Transform player)
    {


        rigidbody.velocity = Vector2.zero;

        rigidbody.angularVelocity = 0f;

        transform.up = player.position - transform.position;

        Invoke("reinforcePull", 0.3f);

    }

    void reinforcePull()
    {

        rigidbody.AddRelativeForce(Vector2.up * 500);


    }

    private void OnCollisionEnter2D(Collision2D other)
    {


        if(other.gameObject.tag == "Player")
        {

        }
        else
        {
            numOfBounces++;
            //animator.SetBool("HasHit", true);

            if (other.gameObject.tag == "Enemy")
            {

                GetComponent<Rigidbody2D>().AddForce(-transform.up * speed);
                
                other.transform.SendMessage("TakeDamage", damage, messageOptions);
                GameObject.FindGameObjectWithTag("Player").GetComponent<ComboManager>().increaseComboByAmount(2);
            }

        }

        if(numOfBounces >= 10)
        {
            Destroy(gameObject);
        }


    }

    void modifyDamage(float modifier)
    {

        damage = damage * modifier;

    }


}
