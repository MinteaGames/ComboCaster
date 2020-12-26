using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rigidbody;

    public static float speed = 6;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        speed = speed * StatMenu.dexM;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.D) &! Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.A) &! Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.S) &! Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.W) &! Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.up * (speed / 1.5f) * Time.deltaTime + Vector3.left * (speed / 1.5f) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.up * (speed / 1.5f) * Time.deltaTime + Vector3.right * (speed / 1.5f) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * (speed / 1.5f) * Time.deltaTime + Vector3.right * (speed / 1.5f) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.down * (speed / 1.5f) * Time.deltaTime + Vector3.left * (speed / 1.5f) * Time.deltaTime;
        }







    }
}
