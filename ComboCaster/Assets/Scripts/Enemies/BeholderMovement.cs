using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderMovement : MonoBehaviour
{

    GameObject player;

    bool turnCool = true;

    bool turnRight = true;

    private float knockBackDistance = 0f;

    bool nearEntity = false;

    Vector3 dir;

    Collider2D closeEntity;
   

    // Start is called before the first frame update
    void Start()
    {
        

        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if (knockBackDistance == 0)
        {

            

            if (turnCool == true)
            {
                turnCool = false;
                Invoke("TurnCooldown", 5f);
            }

            if (nearEntity == false)
            {
                dir = transform.position - player.transform.position;
                dir = dir.normalized;

                transform.position += dir * Time.deltaTime * -0.5f;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -1f * Time.deltaTime);
            }


            if (turnRight == true)
            {
                transform.position += transform.right * 0.2f * Time.deltaTime;
            }
            else
            {
                transform.position += -transform.right * 0.2f * Time.deltaTime;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -2 * Time.deltaTime);
            knockBackDistance -= 1;
        }
        
    }


    void TurnCooldown()
    {
        nearEntity = false;

        turnCool = true;


        if (turnRight == true)
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
       

        if(entity.tag == "Player")
        {
            nearEntity = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, entity.transform.position, -1f * Time.deltaTime);
        }


    }

    void KnockBack(float distance)
    {
        knockBackDistance = distance;
    }


}
