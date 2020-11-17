using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyChasePlayer : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float stopDistance;

    public GameObject[] allGoblins;

    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
