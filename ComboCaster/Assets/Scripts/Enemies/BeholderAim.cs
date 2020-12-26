using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderAim : MonoBehaviour
{


    GameObject player;

    bool projectileCool = true;

    public GameObject projectile;

    float wisMod;

    // Start is called before the first frame update
    void Start()
    {
        wisMod = StatMenu.EwisM;

        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        

            if (projectileCool == true)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                projectileCool = false;
                Invoke("projectileCooldown", 2f / wisMod);
            }

    }

    private void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
    }


    void projectileCooldown()
    {

        projectileCool = true;

    }

}
