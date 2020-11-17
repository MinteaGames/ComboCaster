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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Exit")
        {

            nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                        

            SceneManager.LoadScene(4);

        }
        
        if((other.tag == "Enemy") && invulnerable == false)
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
        Instantiate(deadPlayer, gameObject.transform.position, gameObject.transform.rotation);

        Destroy(gameObject);
    }

}
