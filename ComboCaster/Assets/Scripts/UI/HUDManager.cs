using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    GameObject playerHud;
    [SerializeField]
    UnityEngine.UI.Image[] cooldownIndicators;

    Color red = new Color32(255, 0, 0, 80);
    Color black = new Color32(0, 0, 0, 75);
    ComboManager comboVal;

    // Start is called before the first frame update
    void Start()
    {
        //create an array of UI images equal to the number of abilities and puts the cooldown images into the array
        cooldownIndicators = new UnityEngine.UI.Image[8];
        playerHud = GameObject.Find("player abilities");
        comboVal = GameObject.Find("Player").GetComponent<ComboManager>();
        for (int i = 0; i < 8; i++)
        {
           cooldownIndicators[i] =  playerHud.transform.GetChild(i + 1).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();
            //cooldownIndicators[i].fillAmount = 0;
        }
    }


    /// <summary>
    /// railgun 3
    /// shockwave 5
    /// bounce 6
    /// fireball (initial 5)
    /// </summary>

    private void Update()
    {
        //sets the color and fill ammount for each ability based on the value of the players combo



        if (comboVal.playerCombo >= 15)
        {
            EnoughMana(3);
            EnoughMana(4);
            EnoughMana(5);
            EnoughMana(6);
            EnoughMana(7);
        }
        else if (comboVal.playerCombo >= 6)
        {
            EnoughMana(3);
            notEnoughMana(4);
            EnoughMana(5);
            EnoughMana(6);
            notEnoughMana(7);
        }
        else if(comboVal.playerCombo >= 3)
        {
            EnoughMana(3);
            notEnoughMana(4);
            notEnoughMana(5);
            notEnoughMana(6);
            notEnoughMana(7);
        }
        else
        {
            notEnoughMana(3);
            notEnoughMana(4);
            notEnoughMana(5);
            notEnoughMana(6);
            notEnoughMana(7);
        }
    }

    private void notEnoughMana(int abilityNum)
    {
        cooldownIndicators[abilityNum].fillAmount = 1;
        cooldownIndicators[abilityNum].color = red;
    }
    private void EnoughMana(int abilityNum)
    {
        cooldownIndicators[abilityNum].fillAmount = 0;
        cooldownIndicators[abilityNum].color = black;
    }


    public void InstantReset()
    {
        cooldownIndicators[1].fillAmount = 0;
    }

    public IEnumerator ShowcooldownOfAbility(int abilityUsed, float cooldownLength)
    {
        float timePassed = 0;
        //fills the image with grey overlay
        cooldownIndicators[abilityUsed].fillAmount = 1;

        while (timePassed < cooldownLength+.01)
        {
            //gradually empty the cooldown overlay based on how much time has passed.
            cooldownIndicators[abilityUsed].fillAmount = Mathf.Lerp(1, 0, timePassed / cooldownLength);
            timePassed += Time.deltaTime;
            yield return null;
        }
    }
}
