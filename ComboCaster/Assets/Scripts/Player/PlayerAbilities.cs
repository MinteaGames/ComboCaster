﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{

    Rigidbody2D rigidbody;

    public float dashSpeed = 50;

    bool dashCooldown = true;

    public int initialDashCooldown = 3;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown == true)
        {



            
            if (Input.GetKey(KeyCode.D) & !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
            {
                rigidbody.velocity = Vector2.right * dashSpeed;
                dashCooldown = false;
                Invoke("DashReset", 0.1f);
            }
            if (Input.GetKey(KeyCode.A) & !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
            {
                rigidbody.velocity = Vector2.left * dashSpeed;
                dashCooldown = false;
                Invoke("DashReset", 0.1f);
            }
            if (Input.GetKey(KeyCode.S) & !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
            {
                rigidbody.velocity = Vector2.down * dashSpeed;
                dashCooldown = false;
                Invoke("DashReset", 0.1f);
            }
            if (Input.GetKey(KeyCode.W) & !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
            {
                rigidbody.velocity = Vector2.up * dashSpeed;
                dashCooldown = false;
                Invoke("DashReset", 0.1f);
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {

                rigidbody.velocity += (Vector2.up * (dashSpeed / 1.5f)) + (Vector2.left * (dashSpeed / 1.5f));
                dashCooldown = false;
                Invoke("DashReset", 0.1f);
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                rigidbody.velocity += (Vector2.up * (dashSpeed / 1.5f)) + (Vector2.right * (dashSpeed / 1.5f));
                dashCooldown = false;
                Invoke("DashReset", 0.1f);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                rigidbody.velocity += (Vector2.down * (dashSpeed / 1.5f)) + (Vector2.right * (dashSpeed / 1.5f));
                dashCooldown = false;
                Invoke("DashReset", 0.1f);
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                rigidbody.velocity += (Vector2.down * (dashSpeed / 1.5f)) + (Vector2.left * (dashSpeed / 1.5f));
                dashCooldown = false;
                Invoke("DashReset", 0.1f);
            }
            else
            {
                //rigidbody.velocity = Vector2.right * dashSpeed;
                //dashCooldown = false;
                //Invoke("DashReset", 0.1f);
            }





        }


    }
    void DashReset()
    {

        rigidbody.velocity = Vector2.zero;
        Invoke("DashCooldown", initialDashCooldown);
    }

    void DashCooldown()
    {

        dashCooldown = true;

    }


}