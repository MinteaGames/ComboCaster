using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 1;

    public GameObject life;

    // Start is called before the first frame update
    void Start()
    {
        health = health * StatMenu.EconM;




    }

    void TakeDamage(float damage)
    {

        health = health - damage;

        if(health < 1)
        {
            PlayerScore.Instance.SendMessage("AddScore", GetComponent<enemyScore>().enemyBaseScore);

            if(Random.Range(0,100) < (2 * StatMenu.conM))
            {

                Instantiate(life, transform.position, transform.rotation);

            }

            Destroy(gameObject);    
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
