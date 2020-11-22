using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatMenu : MonoBehaviour
{

    Scene nextScene;

    public Text currentComboText;
    public Text dice;

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

    public Text conMt;
    public Text inteMt;
    public Text strMt;
    public Text dexMt;
    public Text wisMt;
    public Text chaMt;

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

    public Text enemyConM;
    public Text enemyInteM;
    public Text enemyStrM;
    public Text enemyDexM;
    public Text enemyWisM;
    public Text enemyChaM;

    public static float EconM;
    public static float EinteM;
    public static float EstrM;
    public static float EdexM;
    public static float EwisM;
    public static float EchaM;




    int diceMax = 11;
    int diceMin = 0;


    float diceVal1 = 0;
    float diceVal2 = 0;
    float diceVal3 = 0;
    float diceValFin = 0;

    // Start is called before the first frame update
    void Start()
    {

        currentComboText.text = curCombo.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EconM = 1 + diceVal1 / 10f;
        enemyConM.text = "x" + EconM.ToString();
        enemyConT.text = diceVal1.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EinteM = 1 + diceVal1 / 10f;
        enemyInteM.text = "x" + EinteM.ToString();
        enemyInteT.text = diceVal1.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EstrM = 1 + diceVal1 / 10f;
        enemyStrM.text = "x" + EstrM.ToString();
        enemyStrT.text = diceVal1.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EdexM = 1 + diceVal1 / 10f;
        enemyDexM.text = "x" + EdexM.ToString();
        enemyDexT.text = diceVal1.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EwisM = 1 + diceVal1 / 10f;
        enemyWisM.text = "x" + EwisM.ToString();
        enemyWisT.text = diceVal1.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EchaM = 1 + diceVal1 / 10f;
        enemyChaM.text = "x" + EchaM.ToString();
        enemyChaT.text = diceVal1.ToString();



        if (curCombo < 5)
        {

            dice.text = "1";

            diceVal1 = Random.Range(diceMin, diceMax);
            conM = 1 + diceVal1 / 10f;
            conMt.text = "x" + conM.ToString();
            conV.text = diceVal1.ToString();
            conT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            inteM = 1 + diceVal1 / 10f;
            inteMt.text = "x" + inteM.ToString();
            inteV.text = diceVal1.ToString();
            inteT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            strM = 1 + diceVal1 / 10f;
            strMt.text = "x" + strM.ToString();
            strV.text = diceVal1.ToString();
            strT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            dexM = 1 + diceVal1 / 10f;
            dexMt.text = "x" + dexM.ToString();
            dexV.text = diceVal1.ToString();
            dexT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            wisM = 1 + diceVal1 / 10f;
            wisMt.text = "x" + wisM.ToString();
            wisV.text = diceVal1.ToString();
            wisT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            chaM = 1 + diceVal1 / 10f;
            chaMt.text = "x" + chaM.ToString();
            chaV.text = diceVal1.ToString();
            chaT.text = diceVal1.ToString();


            

        }
        else if(curCombo < 10)
        {
            dice.text = "2";


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            conM = 1 + diceValFin / 10f;
            conMt.text = "x" + conM.ToString();
            conV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            conT.text = diceValFin.ToString();


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            inteM = 1 + diceValFin / 10f;
            inteMt.text = "x" + inteM.ToString();
            inteV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            inteT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            strM = 1 + diceValFin / 10f;
            strMt.text = "x" + strM.ToString();
            strV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            strT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            dexM = 1 + diceValFin / 10f;
            dexMt.text = "x" + dexM.ToString();
            dexV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            dexT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            wisM = 1 + diceValFin / 10f;
            wisMt.text = "x" + wisM.ToString();
            wisV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            wisT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            chaM = 1 + diceValFin / 10f;
            chaMt.text = "x" + chaM.ToString();
            chaV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            chaT.text = diceValFin.ToString();


        }
        else
        {
            dice.text = "3";


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            conM = 1 + diceValFin / 10f;
            conMt.text = "x" + conM.ToString();
            conV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            conT.text = diceValFin.ToString();


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            inteM = 1 + diceValFin / 10f;
            inteMt.text = "x" + inteM.ToString();
            inteV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            inteT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            strM = 1 + diceValFin / 10f;
            strMt.text = "x" + strM.ToString();
            strV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            strT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            dexM = 1 + diceValFin / 10f;
            dexMt.text = "x" + dexM.ToString();
            dexV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            dexT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            wisM = 1 + diceValFin / 10f;
            wisMt.text = "x" + wisM.ToString();
            wisV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            wisT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            chaM = 1 + diceValFin / 10f;
            chaMt.text = "x" + chaM.ToString();
            chaV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            chaT.text = diceValFin.ToString();



        }


    }

    public void Continue()
    {
        SceneManager.LoadScene(WorldInteraction.nextSceneIndex);
    }


}
