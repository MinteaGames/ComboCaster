using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldInteraction : MonoBehaviour
{
    
    public static int nextSceneIndex;

    public static int currentcombo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Exit")
        {

            nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            print(nextSceneIndex);

            

            SceneManager.LoadScene(0);

        }
        

    }



}
