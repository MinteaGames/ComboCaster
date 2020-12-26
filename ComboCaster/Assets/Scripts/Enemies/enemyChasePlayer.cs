using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyChasePlayer : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float stopDistance;

    public GameObject[] allGoblins;

    private float knockBackDistance = 0f;

    // Update is called once per frame
    private void Start()
    {

        speed = speed * StatMenu.EdexM;

        player = GameObject.FindGameObjectWithTag("Player").transform;
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
    }

    void KnockBack(float distance)
    {
        knockBackDistance = distance;
    }
}
