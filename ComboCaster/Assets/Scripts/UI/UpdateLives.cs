using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLives : MonoBehaviour
{

    public static bool currentRoom = false;

    public static int numOfLives = 3;

    public Sprite lives1;
    public Sprite lives2;
    public Sprite lives3;


    Image spriteImage;

    public GameObject player;

    public GameObject lostLifeUI;
    public GameObject gameOverUI;


    // Start is called before the first frame update
    void Start()
    {
        spriteImage = gameObject.GetComponent<Image>();
        player = GameObject.Find("Player");

        

        if(numOfLives == 3)
        {
            spriteImage.sprite = lives3;
        }
        if (numOfLives == 2)
        {
            spriteImage.sprite = lives2;
        }
        else if (numOfLives == 1)
        {
            spriteImage.sprite = lives1;
        }
        

    }

    
    void LifeDecrement()
    {

        numOfLives--;

        if(numOfLives == 2)
        {

            spriteImage.sprite = lives2;
            player.SendMessage("Died");
            lostLifeUI.SetActive(true);

        }
        else if(numOfLives == 1)
        {

            spriteImage.sprite = lives1;
            player.SendMessage("Died");
            lostLifeUI.SetActive(true);

        }
        else if(numOfLives == 0)
        {

            spriteImage.enabled = false;
            player.SendMessage("Died");
            gameOverUI.SetActive(true);
            
        }

    }


    void LifeIncrement()
    {

        if(numOfLives < 3)
        {
            numOfLives++;
        }

        if(numOfLives == 3)
        {

            spriteImage.sprite = lives3;

        }
        if (numOfLives == 2)
        {

            spriteImage.sprite = lives2;

        }
        else if (numOfLives == 1)
        {

            spriteImage.sprite = lives1;

        }

    }

    void LifeReset()
    {

        numOfLives = 3;

        spriteImage.enabled = true;

        spriteImage.sprite = lives3;

    }


}
