using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeSwing : MonoBehaviour
{
    public float speed = 0;

    public float damage = 1;

    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Debug.Log("enemy hit");
            other.transform.SendMessage("TakeDamage", damage, messageOptions);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ComboManager>().increaseComboByAmount(2);
            //Destroy(gameObject);
        }
    }
    private void Update()
    {
        Invoke("timeToDie", .1f);
    }

    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}

    private void timeToDie()
    {
        Destroy(gameObject);
    }

    void modifyDamage(float modifier)
    {

        damage = damage * modifier;

    }
}
