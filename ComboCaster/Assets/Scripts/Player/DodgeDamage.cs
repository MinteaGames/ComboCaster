using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeDamage : MonoBehaviour
{
    public static bool dodging = false;

    float damage = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy" && dodging == true)
        {
            
            collision.transform.SendMessage("TakeDamage", damage);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ComboManager>().increaseComboByAmount(2);
            PlayerAbilities.dashCooldown = true;

        }


    }


}
