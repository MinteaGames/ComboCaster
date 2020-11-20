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

    public void increaseCombo()
    {
        playerCombo++;
        timeTillTrickle = resetTrickleTime;
    }

    public void increaseComboByAmount(int increase)
    {
        playerCombo = playerCombo + increase;
        timeTillTrickle = resetTrickleTime;
    }


    public void reduceComboByAmmount(int abilityCost)
    {
        playerCombo -= abilityCost;    
    }

    private void Update()
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

        comboText.text = playerCombo.ToString() + "x";

    }
}
