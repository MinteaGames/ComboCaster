using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    public int playerCombo;

    public Text comboText;

    private float timeTillTrickle;
    public float resetTrickleTime;
    private float timeBetweenDecrease;

    // Stop all increases and decreases
    public bool pauseComboEffects = false;

    GameObject soundboard;


    void Start()
    {
        soundboard = GameObject.Find("Sound Board");
        pauseComboEffects = false;
    }

    public void increaseCombo()
    {
        if (pauseComboEffects == false)
        {
            playerCombo++;
            timeTillTrickle = resetTrickleTime;
            soundboard.SendMessage("playSound", 10, 0);
        }
    }

    public void increaseComboByAmount(int increase)
    {
        if (pauseComboEffects == false)
        {
            playerCombo = playerCombo + increase;
            timeTillTrickle = resetTrickleTime;
            soundboard.SendMessage("playSound", 10, 0);
        } 
    }


    public void reduceComboByAmmount(int abilityCost)
    {
        if (pauseComboEffects == false)
            playerCombo -= abilityCost;    
    }

    private void Update()
    {
        if (pauseComboEffects == false)
        {
            if (timeTillTrickle > 0 && playerCombo != 0)
            {
                timeTillTrickle -= Time.deltaTime;
            }
            else if (timeBetweenDecrease < 0)
            {
                playerCombo--;
                timeBetweenDecrease = 0.5f;
            }
            else
            {
                timeBetweenDecrease -= Time.deltaTime;
            }

            if (playerCombo < 0)
            {
                playerCombo = 0;
            }

            WorldInteraction.currentcombo = playerCombo;

        }
        if (comboText)
        {
            //Debug.Log("update combo");
            comboText.text = playerCombo.ToString() + "x";
        }

    }
}
