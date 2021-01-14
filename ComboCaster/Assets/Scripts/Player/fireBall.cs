using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    const float constDamage = 2;
    public static float damage = 2;
    public float speed = 100;

    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;

    public Animator fireballAnimator;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        damage = constDamage;
        damage = damage * StatMenu.inteM;
    }

    // Update is called once per frame
    void Update()
    {

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

    private void increaseSize()
    {
        this.transform.localScale += new Vector3(2f, 2f, 2f);
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
    }

    private void fire()
    {
        Debug.Log("FIRE");
        transform.parent = null;
        fireballAnimator.SetBool("fireBallFired", true);
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }
}
