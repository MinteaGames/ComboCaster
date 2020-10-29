using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


    public GameObject magicMissle;

    bool magicMissileCool = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0) && magicMissileCool == true)
        {
            Instantiate(magicMissle, transform.position, transform.rotation);
            magicMissileCool = false;
            Invoke("MagicMissileCooldown", 0.5f);
        }

        

    }



    void MagicMissileCooldown()
    {
        magicMissileCool = true;
    }

}
