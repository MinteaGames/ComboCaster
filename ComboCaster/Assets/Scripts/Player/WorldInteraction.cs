using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldInteraction : MonoBehaviour
{
    
    public static int nextSceneIndex;

    public static int currentcombo;

    public GameObject lifeScript;

    bool invulnerable = false;

    Renderer playerRenderer;

    public GameObject deadPlayer;

    // Start is called before the first frame update
    void Start()
    {
        lifeScript = GameObject.Find("Lives");
        playerRenderer = gameObject.GetComponent<Renderer>();
    }


   // private void OnCollisionEnter2D(Collision2D other)
   // {
   //     if (other.gameObject.name == "Exit")
   //     {
   //
   //         nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
   //
   //         SceneManager.LoadScene(10);
   //
   //     }
   //     
   //     if((other.gameObject.tag == "Enemy") && invulnerable == false)
   //     {
   //
   //         lifeScript.SendMessage("LifeDecrement");
   //
   //     }
   //
   //
   //
   // }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Exit")
        {

            nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;


            SceneManager.LoadScene(10);

        }

        if ((collision.gameObject.tag == "Enemy") && invulnerable == false)
        {

            lifeScript.SendMessage("LifeDecrement");

        }


        if ((collision.gameObject.tag == "LifeUp"))
        {

            lifeScript.SendMessage("LifeIncrement");

            Destroy(collision.gameObject);

        }

        if((collision.gameObject.tag == "EnemyProjectile") && invulnerable == false)
        {
            lifeScript.SendMessage("LifeDecrement");
        }

    }


    void TriggerInvulnerability()
    {
        invulnerable = true;
        playerRenderer.material.color = Color.blue;
        Invoke("ResetInvulnerability", 0.3f);
    }

    void ResetInvulnerability()
    {
        invulnerable = false;
        playerRenderer.material.color = Color.white;
    }

    void Died()
    {
        Quaternion rotation = Quaternion.Euler(0,0,90);

        Instantiate(deadPlayer, gameObject.transform.position , rotation);

        Destroy(gameObject);
    }

}
