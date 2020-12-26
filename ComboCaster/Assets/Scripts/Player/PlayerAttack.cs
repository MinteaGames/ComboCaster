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
    public GameObject wish;

    public GameObject soundBoard;


    HUDManager playerHud;

    bool magicMissileCool = true;
    public bool railgunCool = true;
    bool meleeCool = true;
    bool bounceCool = true;
    bool shockCool = true;
    bool fireBallCool = true;

    bool fireBallCharging = false;
    float fireBallChargeTime = 0;
    GameObject currentFireBall = null;
    bool fireBallStage2 = false;
    bool fireBallStage3 = false;

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
    
    wish = GameObject.Find("Combo Mana");

        soundBoard = GameObject.Find("Sound Board");
    }


    // Update is called once per frame
    void Update()
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

                soundBoard.SendMessage("playSound", 2 , 0);
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
            if (Input.GetKey(KeyCode.Alpha2) && fireBallCool == true)
            {
                if (fireBallCharging == false && GetComponentInParent<ComboManager>().playerCombo >= Mathf.RoundToInt(5 / chaMod))
                {



                    soundBoard.SendMessage("playSound", 5, 0);
                    currentFireBall = Instantiate(fireBall, transform.position, transform.rotation, gameObject.transform);
                    fireBallChargeTime += 1;
                    fireBallCharging = true;
                    GetComponentInParent<ComboManager>().reduceComboByAmmount(Mathf.RoundToInt(5 / chaMod));
                    
                     
                    

                }
                else if (fireBallCharging == true && GetComponentInParent<ComboManager>().playerCombo >= 2)
                {
                    fireBallChargeTime += Time.deltaTime;
                    

                    if (fireBallChargeTime >= 2 && fireBallChargeTime < 3)
                    {
                        if (fireBallStage2 == false)
                        {
                            GetComponentInParent<ComboManager>().reduceComboByAmmount(2);
                            fireBallStage2 = true;
                        }
                    }
                    else if (fireBallChargeTime >= 3 && fireBallChargeTime < 4)
                    {
                        if (fireBallStage2 == false)
                        {
                            GetComponentInParent<ComboManager>().reduceComboByAmmount(2);
                            fireBallStage3 = true;
                        }
                    }
                    if (fireBallChargeTime >= 4)
                    {
                        currentFireBall.SendMessage("maxSizeReached");
                    }
                }
                else if (fireBallCharging == true && GetComponentInParent<ComboManager>().playerCombo < 2)
                {
                    currentFireBall.SendMessage("maxSizeReached");
                }
            }

            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                if (fireBallStage2 == true)
                {
                    if (fireBallStage3 == true)
                    {
                        currentFireBall.SendMessage("stageReached", 3);
                    }
                    else
                    {
                        currentFireBall.SendMessage("stageReached", 2);
                    }
                    currentFireBall.SendMessage("stageReached", 2);
                }

                soundBoard.SendMessage("playSound", 6, 0);

                fireBallCool = false;
                Invoke("fireBallCooldown", 0.3f / wisMod);
                fireBallCharging = false;
                fireBallChargeTime = 0;
                fireBallStage2 = false;
                fireBallStage3 = false;

                currentFireBall.SendMessage("fire");
                currentFireBall = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && GetComponentInParent<ComboManager>().playerCombo > 50)
        {
            soundBoard.SendMessage("playSound", 7, 0);
            wish.SendMessage("ReRollStats");
            GetComponentInParent<ComboManager>().reduceComboByAmmount(Mathf.RoundToInt(50 / chaMod));
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
