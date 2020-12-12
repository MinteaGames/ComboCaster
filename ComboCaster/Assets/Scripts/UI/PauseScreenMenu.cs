using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenMenu : MonoBehaviour
{

    private GameObject abilities;

    // Start is called before the first frame update
    void Start()
    {

        abilities = GameObject.Find("Player");

    }

    
    public void resume()
    {

        abilities.SendMessage("pauseGame");

    }

    public void quit()
    {

        Application.Quit();

    }



}
