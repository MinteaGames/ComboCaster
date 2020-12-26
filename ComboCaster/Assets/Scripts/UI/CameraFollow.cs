using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{




    //sets the target
    public Transform target;
    //controls the smoothness of the movement
    public float smoothing = 5.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //creates a new position using target and camera's z
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        //asign position of camera using Lerp animation
        //                                    from             to            time
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));

    }

    }
