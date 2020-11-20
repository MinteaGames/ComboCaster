using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderMovement : MonoBehaviour
{

    GameObject player;

    bool projectileCool = true;

    bool turnRight = true;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {

        transform.up = player.transform.position - transform.position;

        if(projectileCool == true)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            projectileCool = false;
            Invoke("projectileCooldown", 2f);
        }


        transform.position += transform.up * 0.2f * Time.deltaTime;

        if(turnRight == true)
        {
            transform.position += transform.right * 1f * Time.deltaTime;
        }
        else
        {
            transform.position += -transform.right * 1f * Time.deltaTime;
        }
        
    }


    void projectileCooldown()
    {

        projectileCool = true;


        if(turnRight == true)
        {
            turnRight = false;
        }
        else
        {
            turnRight = true;
        }

    }

    void EntityNearby(Collider2D entity)
    {

        

        Vector3 entityDir = transform.position - entity.transform.position;


        transform.position += entityDir * 0.2f * Time.deltaTime;


    }


}
