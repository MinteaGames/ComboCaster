using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenMenu : MonoBehaviour
{

    private GameObject abilities;

    GameObject soundBoard;

    // Start is called before the first frame update
    void Start()
    {

        abilities = GameObject.Find("Player");

        soundBoard = GameObject.Find("Sound Board");

        

    }

    
    public void resume()
    {

        soundBoard.SendMessage("playSound", 13, 0);
        abilities.SendMessage("pauseGame");

    }

    public void quit()
    {

        soundBoard.SendMessage("playSound", 13, 0);
        Application.Quit();

    }



}
