﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


    public GameObject magicMissle;
    public GameObject railgun;
    public GameObject melee;

    bool magicMissileCool = true;
    public bool railgunCool = true;
    bool meleeCool = true;


    

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0) && magicMissileCool == true)
        {
            Instantiate(magicMissle, transform.position, transform.rotation);
            magicMissileCool = false;
            Invoke("MagicMissileCooldown", 0.3f);
        }
        if ((Input.GetKeyDown("e")) && (railgunCool == true) && (GetComponentInParent<ComboManager>().playerCombo >= 3))
        {
            Instantiate(railgun, transform.position, transform.rotation);
            GetComponentInParent<ComboManager>().reduceComboByAmmount(3);
            railgunCool = false;
            Invoke("railgunCooldown", 1.0f);
        }
        if (Input.GetMouseButton(1) && meleeCool == true)
        {
            Instantiate(melee, transform.position, transform.rotation);  
            meleeCool = false;
            Invoke("meleeCooldown", 0.3f);
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

}
