using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject soundBoard;

    public void Start()
    {
        print("main menu");

        StatMenu.conM = 1;
        StatMenu.inteM = 1;
        StatMenu.strM = 1;
        StatMenu.dexM = 1;
        StatMenu.wisM = 1;
        StatMenu.chaM = 1;


        StatMenu.EconM = 1;
        StatMenu.EinteM = 1;
        StatMenu.EstrM = 1;
        StatMenu.EdexM = 1;
        StatMenu.EwisM = 1;
        StatMenu.EchaM = 1;

        soundBoard = GameObject.Find("Sound Board");

        soundBoard.SendMessage("playSound", 16, 0);

    }

    public void quit()
    {
        soundBoard.SendMessage("playSound", 13, 0);
        Application.Quit();
    }

    public void play()
    {
        soundBoard.SendMessage("playSound", 13, 0);
        SceneManager.LoadScene("Level_1");
    }

    public void tutorial()
    {
        soundBoard.SendMessage("playSound", 13, 0);
        SceneManager.LoadScene("Part1");
    }
}
