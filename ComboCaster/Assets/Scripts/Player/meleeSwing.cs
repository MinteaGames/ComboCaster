using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeSwing : MonoBehaviour
{
    public float speed = 0;

    public static float damage = 2;
    public float knockBackDistance = 1f;
    public static bool flipped = false;

    private Rigidbody2D rb2D;

    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;

    // Start is called before the first frame update
    void Start()
    {

        damage = damage * StatMenu.strM;

        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.up * speed);

        Vector3 scaleVec = new Vector3(0, 0, 0);



        if (flipped == false)
        {
            scaleVec = new Vector3(-2.7296f, 0, 0);
            flipped = true;
        }
        else
        {
            scaleVec = new Vector3(0, 0, 0);
            flipped = false;
        }
        

        transform.localScale += scaleVec;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Debug.Log("enemy hit");
            other.transform.SendMessage("TakeDamage", damage, messageOptions);
            
            other.transform.SendMessage("KnockBack", knockBackDistance, messageOptions);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ComboManager>().increaseComboByAmount(2);
            //Destroy(gameObject);
        }
    }
    private void Update()
    {
        Invoke("timeToDie", .5f);
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
