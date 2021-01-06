using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemyChasePlayer : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float stopDistance;

    public GameObject[] allGoblins;

    private float knockBackDistance = 0f;

    private Animator anim;

    // Update is called once per frame
    private void Start()
    {

        speed = speed * StatMenu.EdexM;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = gameObject.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (knockBackDistance != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -2 * speed * Time.deltaTime);
            knockBackDistance -= 1;
        }
        else
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }

        //CalculateSprite();
    }

    void KnockBack(float distance)
    {
        knockBackDistance = distance;
    }

   // void CalculateSprite()
   // {
   //     Vector3 dir = player.transform.position - transform.position;
   //     float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
   //     int rotateState = Convert.ToInt32(Quaternion.AngleAxis(angle - 90, Vector3.forward).eulerAngles.z / 90.0f);
   //
   //     anim.SetInteger("direction", rotateState);
   // }
}
