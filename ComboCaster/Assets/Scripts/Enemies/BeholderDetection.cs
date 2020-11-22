using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderDetection : MonoBehaviour
{

    GameObject beholder;

    // Start is called before the first frame update
    void Start()
    {
        beholder = gameObject.transform.parent.gameObject;
        
    }



    private void OnTriggerStay2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            beholder.SendMessage("EntityNearby", collision);
        }
        else if(collision.tag == "Enemy")
        {
            beholder.SendMessage("EntityNearby", collision);
        }

    }

}
