using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    GameObject playerHud;
    [SerializeField]
    UnityEngine.UI.Image[] cooldownIndicators;

    bool[] onCooldown;

    public int abilityCast;

    float cooldownRemain;
    // Start is called before the first frame update
    void Start()
    {
        cooldownIndicators = new UnityEngine.UI.Image[8];

        playerHud = GameObject.Find("player abilities");
        for (int i = 0; i < 8; i++)
        {
           cooldownIndicators[i] =  playerHud.transform.GetChild(i + 1).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();
        }
    }

    public IEnumerator ShowcooldownOfAbility(int abilityUsed, float cooldownLength)
    {
        cooldownIndicators[abilityUsed].fillAmount = 0;
        while (cooldownIndicators[abilityUsed].fillAmount != 1)
        {
            cooldownIndicators[abilityUsed].fillAmount -= 1 / cooldownLength * Time.deltaTime;
        }

        yield return null;
    }
}
