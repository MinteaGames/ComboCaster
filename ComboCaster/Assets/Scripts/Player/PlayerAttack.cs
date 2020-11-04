using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


    public GameObject magicMissle;
    public GameObject railgun;

    bool magicMissileCool = true;
    public bool railgunCool = true;


    

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
        

    }

    void railgunCooldown()
    {
        railgunCool = true;
    }

    void MagicMissileCooldown()
    {
        magicMissileCool = true;
    }

}
