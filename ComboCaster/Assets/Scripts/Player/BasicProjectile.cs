using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public Animator animator;

    public float speed = 5;

    public float damage = 1;

    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);

        animator.SetBool("HasHit", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Remove force to get object to stop moving
            GetComponent<Rigidbody2D>().AddForce(-transform.up * speed);
            // Play hit animation which has destroy on end script
            animator.SetBool("HasHit", true);


            //Debug.Log("enemy hit");
            other.transform.SendMessage("TakeDamage", damage, messageOptions);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ComboManager>().increaseCombo();            
        }
        else
        {     
            //Debug.Log("miss");
            Destroy(gameObject);
        }

    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void modifyDamage(float modifier)
    {

        damage = damage * modifier;

    }


}
