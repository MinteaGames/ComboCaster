using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        onCooldown = new bool[8];
        playerHud = GameObject.Find("player abilities");
        for (int i = 0; i < 8; i++)
        {
           cooldownIndicators[i] =  playerHud.transform.GetChild(i + 1).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();
            cooldownIndicators[i].fillAmount = 0;
        }
    }

    public IEnumerator ShowcooldownOfAbility(int abilityUsed, float cooldownLength)
    {
        float timePassed = 0;

        cooldownIndicators[abilityUsed].fillAmount = 1;

        while (timePassed < cooldownLength+.01)
        {
            cooldownIndicators[abilityUsed].fillAmount = Mathf.Lerp(1, 0, timePassed / cooldownLength);
            timePassed += Time.deltaTime;
            yield return null;
        }
    }
}
