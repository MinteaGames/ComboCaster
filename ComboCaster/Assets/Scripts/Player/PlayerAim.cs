using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{


    public Camera theCamera;
    public float smoothing = 5f;
    public float adjustmentAngle = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 currentPosition = transform.position;

        Quaternion currentRotation = transform.rotation;

        Vector3 mousePosition = Input.mousePosition;

        Vector3 targetMousePosition = theCamera.ScreenToWorldPoint(mousePosition);

        Vector3 difference = targetMousePosition - currentPosition;

        float angleZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;


        Vector3 rotationInDegrees = new Vector3();

        rotationInDegrees.x = 0;
        rotationInDegrees.y = 0;

        rotationInDegrees.z = angleZ + adjustmentAngle;

        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);

        float rotationSpeed = Time.deltaTime * smoothing;

        transform.rotation = Quaternion.Lerp(currentRotation, rotationInRadians, rotationSpeed);

    }
}
