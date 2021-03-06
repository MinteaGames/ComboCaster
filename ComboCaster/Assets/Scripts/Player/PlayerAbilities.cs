﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{

    Rigidbody2D rigidbody;

    public float dashSpeed = 70;

    public static bool dashCooldown = true;

    public int initialDashCooldown = 3;

    BoxCollider2D playerCollider;

    public GameObject dodgeParticle;

    HUDManager playerHud;


    public bool disableDash = false;
    
    public bool paused = false;

    public GameObject pauseScreen;

    GameObject soundboard;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        dashCooldown = true;
        playerHud = GameObject.Find("UI manager").GetComponent<HUDManager>();

        soundboard = GameObject.Find("Sound Board");
        player = GameObject.FindGameObjectWithTag("Player");
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (paused == false)
        {


            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Space))
            {
                pauseGame();
            }

            if (disableDash == false)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown == true)
                {
                    soundboard.SendMessage("playSound", 8, 0);


                    gameObject.layer = 11;

                    gameObject.SendMessage("TriggerInvulnerability");

                    Instantiate(dodgeParticle, transform.position, transform.rotation, transform);

                    DodgeDamage.dodging = true;

                    if (Input.GetKey(KeyCode.D) & !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
                    {
                        rigidbody.velocity = Vector2.right * dashSpeed;

                    }
                    if (Input.GetKey(KeyCode.A) & !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
                    {
                        rigidbody.velocity = Vector2.left * dashSpeed;

                    }
                    if (Input.GetKey(KeyCode.S) & !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
                    {
                        rigidbody.velocity = Vector2.down * dashSpeed;

                    }
                    if (Input.GetKey(KeyCode.W) & !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
                    {
                        rigidbody.velocity = Vector2.up * dashSpeed;

                    }
                    if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
                    {

                        rigidbody.velocity += (Vector2.up * (dashSpeed / 1.5f)) + (Vector2.left * (dashSpeed / 1.5f));

                    }
                    if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                    {
                        rigidbody.velocity += (Vector2.up * (dashSpeed / 1.5f)) + (Vector2.right * (dashSpeed / 1.5f));

                    }
                    if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                    {
                        rigidbody.velocity += (Vector2.down * (dashSpeed / 1.5f)) + (Vector2.right * (dashSpeed / 1.5f));

                    }
                    if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                    {
                        rigidbody.velocity += (Vector2.down * (dashSpeed / 1.5f)) + (Vector2.left * (dashSpeed / 1.5f));
                    }
                    else
                    {
                        //rigidbody.velocity = Vector2.right * dashSpeed;
                        //dashCooldown = false;
                        //Invoke("DashReset", 0.1f);
                    }


                    dashCooldown = false;
                    Invoke("DashReset", 0.1f);


                }
            }
        }

    }

    public void pauseGame()
    {

        if (paused == false)
        {
            paused = true;

            Time.timeScale = 0;

            pauseScreen.active = true;
        }
        else
        {
            paused = false;

            Time.timeScale = 1;

            pauseScreen.active = false;
        }

    }

    void DashReset()
    {
        gameObject.layer = 8;
        rigidbody.velocity = Vector2.zero;
        DodgeDamage.dodging = false;
        Invoke("DashCooldown", initialDashCooldown);
        if(DodgeDamage.hitEnemy == false)
        {
            StartCoroutine(playerHud.ShowcooldownOfAbility(1, initialDashCooldown));
        }
        DodgeDamage.hitEnemy = false;
        
    }

    void DashCooldown()
    {

        dashCooldown = true;

    }


}
