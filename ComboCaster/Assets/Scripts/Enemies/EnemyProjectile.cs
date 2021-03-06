﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Animator animator;

    public float speed = 15;

    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;

    public GameObject magicMissle;
    private bool convert = false;

    // Start is called before the first frame update
    void Start()
    {

        print("spawned");
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);

        GameObject soundBoard = GameObject.Find("Sound Board");

        soundBoard.SendMessage("playSound", 12, 0);

        Invoke("killObject", 10f);

        animator.SetBool("HasHit", false);
    }

    void killObject()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (convert == true)
        {
            Instantiate(magicMissle, transform.position, (Quaternion.Inverse(transform.rotation)* Quaternion.Euler(180, 180, 0)));
            // avoid colliding with instantiated object
            GetComponent<CircleCollider2D>().enabled = false;

            Destroy(this.gameObject);
            convert = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {

        }
        else if (other.name == "Detection")
        {

        }
        else if (other.tag == "KnockBack")
        {
            convert = true;
            transform.rotation = Quaternion.Inverse(transform.rotation);
        }
        else
        {
            // Remove force to get object to stop moving
            GetComponent<Rigidbody2D>().AddForce(-transform.up * speed);
            GetComponent<CircleCollider2D>().enabled = false;
            animator.SetBool("HasHit", true);
        }
    }


    //void modifyDamage(float modifier)
    //{

    //    damage = damage * modifier;

    //}
}
