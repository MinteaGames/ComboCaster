using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(0.02f, 0.02f, 0.02f);
    private bool maxSize = false;

    public float damage = 2;
    public float speed = 100;

    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().enabled = false;

        damage = damage * StatMenu.inteM;
    }

    // Update is called once per frame
    void Update()
    {
        if (maxSize == false)
        {
            this.transform.localScale += scaleChange;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("enemy hit");
            other.transform.SendMessage("TakeDamage", damage, messageOptions);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ComboManager>().increaseCombo();
        }
        else
        {
            Debug.Log("miss");
            Destroy(gameObject);
        }

    }

    private void maxSizeReached()
    {
        maxSize = true;
    }

    private void stageReached(int stage)
    {
        if (stage == 2)
        {
            damage = damage * 2;
        }
        else if (stage == 3)
        {
            damage = damage * 3;
        }

        maxSizeReached();
    }

    private void fire()
    {
        Debug.Log("FIRE");
        transform.parent = null;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }
}
