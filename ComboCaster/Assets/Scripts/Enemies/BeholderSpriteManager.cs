using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderSpriteManager : MonoBehaviour
{
    public int rotateState;
    Transform rotateDir;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rotateDir = transform.GetChild(0).transform;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateState = Convert.ToInt32(rotateDir.eulerAngles.z / 90.0f);

        anim.SetInteger("direction", rotateState);
    }
}
