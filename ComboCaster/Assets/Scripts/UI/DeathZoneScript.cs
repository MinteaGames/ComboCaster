using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "Player")
        {
            collision.transform.position = new Vector3(0, 0, 0);
        }
    }
}
