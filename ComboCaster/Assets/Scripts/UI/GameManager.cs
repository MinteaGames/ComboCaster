using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void quit()
    {
        Application.Quit();
    }

    public void play()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("Part1");
    }
}
