using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{

    public float speed = 5;

    public float damage = 1;

    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {     

        other.transform.SendMessage("TakeDamage", damage, messageOptions);

        Destroy(gameObject);
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
