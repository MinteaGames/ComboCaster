using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ogreSpriteManager : MonoBehaviour
{

    public int rotateState;
    Quaternion rotateDir;
    SpriteRenderer anim;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotateState = Convert.ToInt32(angle / 180.0f);

        if (rotateState == 0)
        {
            anim.flipX = true;
        }
        else
        {
            anim.flipX = false;
        }
        //anim.SetInteger("direction", rotateState);
    }
}
