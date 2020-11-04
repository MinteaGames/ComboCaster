using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatMenu : MonoBehaviour
{

    Scene nextScene;

    public Text currentComboText;

    private int curCombo = WorldInteraction.currentcombo;

    public Text conT;
    public Text inteT;
    public Text strT;
    public Text dexT;
    public Text wisT;
    public Text chaT;

    public Text conV;
    public Text inteV;
    public Text strV;
    public Text dexV;
    public Text wisV;
    public Text chaV;

    public static float conM;
    public static float inteM;
    public static float strM;
    public static float dexM;
    public static float wisM;
    public static float chaM;

    public Text enemyConT;
    public Text enemyInteT;
    public Text enemyStrT;
    public Text enemyDexT;
    public Text enemyWisT;
    public Text enemyChaT;

   

    int diceMax = 11;
    int diceMin = 0;


    float diceVal1 = 0;
    float diceVal2 = 0;
    float diceVal3 = 0;
    float diceValFin = 0;

    // Start is called before the first frame update
    void Start()
    {



        diceVal1 = Random.Range(diceMin, diceMax);
        conM = 1 + diceVal1 / 10f;
        conV.text = diceVal1.ToString() + "   =";
        enemyConT.text = diceVal1.ToString() + "  [" + conM.ToString() + "x Health]";

        diceVal1 = Random.Range(diceMin, diceMax);
        inteM = 1 + diceVal1 / 10f;
        inteV.text = diceVal1.ToString() + "   =";
        enemyInteT.text = diceVal1.ToString() + "  [" + inteM.ToString() + "x Ranged Damage]";

        diceVal1 = Random.Range(diceMin, diceMax);
        strM = 1 + diceVal1 / 10f;
        strV.text = diceVal1.ToString() + "   =";
        enemyStrT.text = diceVal1.ToString() + "  [" + strM.ToString() + "x Melee Damage]";

        diceVal1 = Random.Range(diceMin, diceMax);
        dexM = 1 + diceVal1 / 10f;
        dexV.text = diceVal1.ToString() + "   =";
        enemyDexT.text = diceVal1.ToString() + "  [" + dexM.ToString() + "x Movement Speed]";

        diceVal1 = Random.Range(diceMin, diceMax);
        wisM = 1 + diceVal1 / 10f;
        wisV.text = diceVal1.ToString() + "   =";
        enemyWisT.text = diceVal1.ToString() + "  [" + wisM.ToString() + "x Attack Speed]";

        diceVal1 = Random.Range(diceMin, diceMax);
        chaM = 1 + diceVal1 / 10f;
        chaV.text = diceVal1.ToString() + "   =";
        enemyChaT.text = diceVal1.ToString() + "  [" + chaM.ToString() + "x Ability Frequency]";



        if (curCombo < 5)
        {

            diceVal1 = Random.Range(diceMin, diceMax);
            conM = 1 + diceVal1 / 10f;
            conV.text = diceVal1.ToString() + "   =";
            conT.text = diceVal1.ToString() + "  [" + conM.ToString() + "x Health]";

            diceVal1 = Random.Range(diceMin, diceMax);
            inteM = 1 + diceVal1 / 10f;
            inteV.text = diceVal1.ToString() + "   =";
            inteT.text = diceVal1.ToString() + "  [" + inteM.ToString() + "x Ranged Damage]";

            diceVal1 = Random.Range(diceMin, diceMax);
            strM = 1 + diceVal1 / 10f;
            strV.text = diceVal1.ToString() + "   =";
            strT.text = diceVal1.ToString() + "  [" + strM.ToString() + "x Melee Damage]";

            diceVal1 = Random.Range(diceMin, diceMax);
            dexM = 1 + diceVal1 / 10f;
            dexV.text = diceVal1.ToString() + "   =";
            dexT.text = diceVal1.ToString() + "  [" + dexM.ToString() + "x Movement Speed]";

            diceVal1 = Random.Range(diceMin, diceMax);
            wisM = 1 + diceVal1 / 10f;
            wisV.text = diceVal1.ToString() + "   =";
            wisT.text = diceVal1.ToString() + "  [" + wisM.ToString() + "x Attack Speed]";

            diceVal1 = Random.Range(diceMin, diceMax);
            chaM = 1 + diceVal1 / 10f;
            chaV.text = diceVal1.ToString() + "   =";
            chaT.text = diceVal1.ToString() + "  [" + chaM.ToString() + "x Ability Cost Reduced]";


            currentComboText.text = "Final Combo: " + curCombo.ToString() + "  = 1 Die";

        }
        else if(curCombo < 10)
        {


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            conM = 1 + diceValFin / 10f;
            conV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "   =";
            conT.text = diceValFin.ToString() + "  [" + conM.ToString() + "x Health]";

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            inteM = 1 + diceValFin / 10f;
            inteV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "   =";
            inteT.text = diceValFin.ToString() + "  [" + inteM.ToString() + "x Ranged Damage]";

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            strM = 1 + diceValFin / 10f;
            strV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "   =";
            strT.text = diceValFin.ToString() + "  [" + strM.ToString() + "x Melee Damage]";

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            dexM = 1 + diceValFin / 10f;
            dexV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "   =";
            dexT.text = diceValFin.ToString() + "  [" + dexM.ToString() + "x Movement Speed]";

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            wisM = 1 + diceValFin / 10f;
            wisV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "   =";
            wisT.text = diceValFin.ToString() + "  [" + wisM.ToString() + "x Attack Speed]";

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            chaM = 1 + diceValFin / 10f;
            chaV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "   =";
            chaT.text = diceValFin.ToString() + "  [" + chaM.ToString() + "x Ability Cost Reduced]";

            currentComboText.text = "Final Combo: " + curCombo.ToString() + "  = 2 Dice";

        }
        else
        {

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            conM = 1 + diceValFin / 10f;
            conV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() +  "  +  " + diceVal3.ToString() + "   =";
            conT.text = diceValFin.ToString() + "  [" + conM.ToString() + "x Health]";

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            inteM = 1 + diceValFin / 10f;
            inteV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString() + "   =";
            inteT.text = diceValFin.ToString() + "  [" + inteM.ToString() + "x Ranged Damage]";

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            strM = 1 + diceValFin / 10f;
            strV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString() + "   =";
            strT.text = diceValFin.ToString() + "  [" + strM.ToString() + "x Melee Damage]";

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            dexM = 1 + diceValFin / 10f;
            dexV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString() + "   =";
            dexT.text = diceValFin.ToString() + "  [" + dexM.ToString() + "x Movement Speed]";

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            wisM = 1 + diceValFin / 10f;
            wisV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString() + "   =";
            wisT.text = diceValFin.ToString() + "  [" + wisM.ToString() + "x Attack Speed]";

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            chaM = 1 + diceValFin / 10f;
            chaV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString() + "   =";
            chaT.text = diceValFin.ToString() + "  [" + chaM.ToString() + "x Ability Cost Reduced]";


            currentComboText.text = "Final Combo: " + curCombo.ToString() + "  = 3 Dice";


        }


    }

    public void Continue()
    {
        SceneManager.LoadScene(WorldInteraction.nextSceneIndex);
    }


}
