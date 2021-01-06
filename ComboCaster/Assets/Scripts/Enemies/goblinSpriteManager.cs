using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinSpriteManager : MonoBehaviour
{
    public int rotateState;
    Quaternion rotateDir;
    Animator anim;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90;
        rotateState = Convert.ToInt32(angle / 90.0f) +2;

        anim.SetInteger("direction", rotateState);
    }
}

