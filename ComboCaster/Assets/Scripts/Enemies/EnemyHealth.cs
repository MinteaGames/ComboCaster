using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void TakeDamage(float damage)
    {

        health = health - damage;

        if(health < 1)
        {
            Destroy(gameObject);
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
