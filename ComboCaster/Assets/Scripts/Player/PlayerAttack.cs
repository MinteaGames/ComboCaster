using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


    public GameObject magicMissle;
    public GameObject railgun;
    public GameObject melee;
    public GameObject bounceBall;
    public GameObject shockWave;
    public GameObject fireBall;
    public GameObject wishData;
    public ParticleSystem wishPS;

    public GameObject soundBoard;

    //GameObject player;

    HUDManager playerHud;

    bool magicMissileCool = true;
    public bool railgunCool = true;
    bool meleeCool = true;
    bool bounceCool = true;
    bool shockCool = true;
    bool fireBallCool = true;


    int fireBallChargeTime = 0;
    GameObject currentFireBall = null;

    public bool disableMagicMissile = false;
    public bool disableRailgun = false;
    public bool disableMelee = false;
    public bool disableBounce = false;
    public bool disableShock = false;
    public bool disableFireball = false;
    public bool disableWish = false;

    public static float wisMod;
    public static float chaMod;

    private void Start()
    {
        wisMod = StatMenu.wisM;

        chaMod = StatMenu.chaM;

		playerHud = GameObject.Find("UI manager").GetComponent<HUDManager>();
    
        wishData = GameObject.Find("Combo Mana");

        soundBoard = GameObject.Find("Sound Board");

        soundBoard.SendMessage("playSound", 15, 0);

        //player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<PlayerAbilities>().paused == false)
        {
            // Magic Missile
            if (disableMagicMissile == false)
            {
                if (Input.GetMouseButton(0) && magicMissileCool == true)
                {
                    Instantiate(magicMissle, transform.position, transform.rotation);
                    magicMissileCool = false;
                    soundBoard.SendMessage("playSound", 0, 0);
                    Invoke("MagicMissileCooldown", 0.3f / wisMod);

                    //playerHud.ShowcooldownOfAbility(0 , 0.3f);
                    StartCoroutine(playerHud.ShowcooldownOfAbility(0, 0.3f / wisMod));
                }
            }

            // Railgun
            if (disableRailgun == false)
            {
                if ((Input.GetKeyDown("e")) && (railgunCool == true) && (GetComponentInParent<ComboManager>().playerCombo >= Mathf.RoundToInt(5 / chaMod)))
                {
                    Instantiate(railgun, transform.position, transform.rotation, transform.parent.transform);
                    GetComponentInParent<ComboManager>().reduceComboByAmmount(Mathf.RoundToInt(5 / chaMod));
                    railgunCool = false;

                    soundBoard.SendMessage("playSound", 2, 0);
                    Invoke("railgunCooldown", 1.0f / wisMod);
                    StartCoroutine(playerHud.ShowcooldownOfAbility(3, 1.0f / wisMod));
                }
            }

            // Melee
            if (disableMelee == false)
            {
                if (Input.GetMouseButton(1) && meleeCool == true)
                {
                    Instantiate(melee, transform.position, transform.rotation, gameObject.transform);
                    meleeCool = false;
                    soundBoard.SendMessage("playSound", 1, 0);

                    Invoke("meleeCooldown", 0.8f / wisMod);
                    StartCoroutine(playerHud.ShowcooldownOfAbility(2, 0.8f / wisMod));

                }
            }

            // Bounce
            if (disableBounce == false)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && bounceCool == true)
                {

                    if (GameObject.Find("Bounce Ball(Clone)") == true)
                    {
                        GameObject.Find("Bounce Ball(Clone)").SendMessage("pullTowardsPlayer", gameObject.transform);
                        bounceCool = false;

                        Invoke("BounceCooldown", 2.0f / wisMod);
                        StartCoroutine(playerHud.ShowcooldownOfAbility(5, 2.0f / wisMod));
                    }
                    else if (GetComponentInParent<ComboManager>().playerCombo >= Mathf.RoundToInt(6 / chaMod))
                    {
                        soundBoard.SendMessage("playSound", 3, 0);

                        bounceCool = false;
                        Instantiate(bounceBall, transform.position, transform.rotation);
                        GetComponentInParent<ComboManager>().reduceComboByAmmount(Mathf.RoundToInt(6 / chaMod));
                        Invoke("BounceCooldown", 2.0f / wisMod);
                        StartCoroutine(playerHud.ShowcooldownOfAbility(5, 2.0f / wisMod));
                    }

                }
            }

            // Shockwave
            if (disableShock == false)
            {
                if (Input.GetKeyDown(KeyCode.Q) && shockCool == true && GetComponentInParent<ComboManager>().playerCombo >= Mathf.RoundToInt(15 / chaMod))
                {

                    soundBoard.SendMessage("playSound", 4, 0);
                    Instantiate(shockWave, transform.position, transform.rotation);
                    shockCool = false;
                    Invoke("ShockCooldown", 10.0f / wisMod);
                    GetComponentInParent<ComboManager>().reduceComboByAmmount(Mathf.RoundToInt(15 / chaMod));
                    StartCoroutine(playerHud.ShowcooldownOfAbility(4, 10.0f / wisMod));
                }
            }

            // Fireball
            if (disableFireball == false)
            {
                if (Input.GetKeyDown(KeyCode.Alpha2) && fireBallCool == true)
                {
                    fireBallChargeTime += 1;
                    disableMagicMissile = true;


                    // Take combo
                    if (fireBallChargeTime == 1 && currentFireBall == null)
                    {
                        soundBoard.SendMessage("playSound", 5, 0);
                        GetComponentInParent<ComboManager>().reduceComboByAmmount(Mathf.RoundToInt(5 / chaMod));

                        currentFireBall = Instantiate(fireBall, transform.position, transform.rotation, gameObject.transform);
                    }
                    else if (fireBallChargeTime == 2 || fireBallChargeTime == 3)
                    {
                        soundBoard.SendMessage("playSound", 5, 0);
                        if (currentFireBall != null)
                        {
                            GetComponentInParent<ComboManager>().reduceComboByAmmount(Mathf.RoundToInt(2 / chaMod));

                            currentFireBall.SendMessage("increaseSize");
                        }
                        else
                        {
                            fireBallChargeTime = 0;
                            disableMagicMissile = false;
                        }
                    }
                    // Return combo & reset fireball
                    else if (fireBallChargeTime == 4)
                    {
                        soundBoard.SendMessage("playSound", 17, 0);
                        fireBallChargeTime = 0;
                        disableMagicMissile = false;
                        GetComponentInParent<ComboManager>().increaseComboByAmount((Mathf.RoundToInt(5 / chaMod)) + (Mathf.RoundToInt(2 / chaMod)) + (Mathf.RoundToInt(2 / chaMod)));

                        Destroy(currentFireBall);
                        currentFireBall = null;
                    }
                }

                if (Input.GetMouseButton(0))
                {
                    if (fireBallChargeTime != 0)
                    {
                        currentFireBall.SendMessage("stageReached", fireBallChargeTime);

                        soundBoard.SendMessage("playSound", 6, 0);

                        fireBallCool = false;
                        Invoke("fireBallCooldown", 0.3f / wisMod);
                        fireBallChargeTime = 0;
                        currentFireBall.SendMessage("fire");
                        currentFireBall = null;

                        disableMagicMissile = false;

                        StartCoroutine(playerHud.ShowcooldownOfAbility(6, 0.3f / wisMod));
                    }
                }
            }

            // Wish
            if (Input.GetKeyDown(KeyCode.Alpha3) && GetComponentInParent<ComboManager>().playerCombo > 50)
            {
                soundBoard.SendMessage("playSound", 7, 0);
                soundBoard.SendMessage("playSound", 11, 0);
                wishPS.Play();
                wishData.SendMessage("ReRollStats");
                GetComponentInParent<ComboManager>().reduceComboByAmmount(Mathf.RoundToInt(50 / chaMod));
                StartCoroutine(playerHud.ShowcooldownOfAbility(7, 1.0f / wisMod));
            }
        }
    }
        void railgunCooldown()
        {
            railgunCool = true;
        }
        void meleeCooldown()
        {
            meleeCool = true;
        }

        void MagicMissileCooldown()
        {
            magicMissileCool = true;
        }

        void BounceCooldown()
        {
            bounceCool = true;
        }
        void ShockCooldown()
        {
            shockCool = true;
        }

        void fireBallCooldown()
        {
            fireBallCool = true;
        }
    
    
    
}
