using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpriteManager : MonoBehaviour
{

    public int rotateState;
    Transform rotateDir;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rotateDir = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        rotateState = Convert.ToInt32(rotateDir.eulerAngles.z / 45.0f);

        anim.SetInteger("direction", rotateState);
    }
}
