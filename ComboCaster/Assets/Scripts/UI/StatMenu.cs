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

    public static float conM = 1;
    public static float inteM = 1;
    public static float strM = 1;
    public static float dexM = 1;
    public static float wisM = 1;
    public static float chaM = 1;

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

    public static float EconM = 1;
    public static float EinteM = 1;
    public static float EstrM = 1;
    public static float EdexM = 1;
    public static float EwisM = 1;
    public static float EchaM = 1;




    int diceMax = 11;
    int diceMin = 0;


    float diceVal1 = 0;
    float diceVal2 = 0;
    float diceVal3 = 0;
    float diceValFin = 0;

    // Start is called before the first frame update
    void Start()
    {

        

        
        if(SceneManager.GetActiveScene().name == "Stat Roll")
        {

            conM = 1;
            inteM = 1;
            strM = 1;
            dexM = 1;
            wisM = 1;
            chaM = 1;


            EconM = 1;
            EinteM = 1;
            EstrM = 1;
            EdexM = 1;
            EwisM = 1;
            EchaM = 1;


            //PlayerMovement.speed = 5;
            //PlayerAttack.wisMod = 1;
            //PlayerAttack.chaMod = 1;
            //BasicProjectile.damage = 1;
            //BounceProjectile.damage = 3;
            //fireBall.damage = 2;
            //RailgunProjectile.damage = 2;
            //ShockWave.damage = 1;
            //DodgeDamage.damage = 2;
            //meleeSwing.damage = 2;

            RollStats();
            RollEnemyStats();
        }
        else
        {
            FillStats();
        }


    }



    void RollStats()
    {

        currentComboText.text = curCombo.ToString();


        if (curCombo < 50)
        {

            dice.text = "1";

            diceVal1 = Random.Range(diceMin, diceMax);
            conM = 0.1f + diceVal1 / 10f;
            conMt.text = "x" + conM.ToString();
            conV.text = diceVal1.ToString();
            conT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            inteM = 0.1f + diceVal1 / 10f;
            inteMt.text = "x" + inteM.ToString();
            inteV.text = diceVal1.ToString();
            inteT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            strM = 0.1f + diceVal1 / 10f;
            strMt.text = "x" + strM.ToString();
            strV.text = diceVal1.ToString();
            strT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            dexM = 0.1f + diceVal1 / 10f;
            dexMt.text = "x" + dexM.ToString();
            dexV.text = diceVal1.ToString();
            dexT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            wisM = 0.8f + ((diceVal1 / 10f) * 0.5f);
            wisMt.text = "x" + wisM.ToString();
            wisV.text = diceVal1.ToString();
            wisT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            chaM = 0.1f + diceVal1 / 10f;
            chaMt.text = "x" + chaM.ToString();
            chaV.text = diceVal1.ToString();
            chaT.text = diceVal1.ToString();




        }
        else if (curCombo < 100)
        {
            dice.text = "2";


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            conM = 0.1f + diceValFin / 10f;
            conMt.text = "x" + conM.ToString();
            conV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            conT.text = diceValFin.ToString();


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            inteM = 0.1f + diceValFin / 10f;
            inteMt.text = "x" + inteM.ToString();
            inteV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            inteT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            strM = 0.1f + diceValFin / 10f;
            strMt.text = "x" + strM.ToString();
            strV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            strT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            dexM = 0.1f + diceValFin / 10f;
            dexMt.text = "x" + dexM.ToString();
            dexV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            dexT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            wisM = 0.8f + ((diceVal1 / 10f) * 0.5f);
            wisMt.text = "x" + wisM.ToString();
            wisV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString();
            wisT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            chaM = 0.1f + diceValFin / 10f;
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
            conM = 0.1f + diceValFin / 10f;
            conMt.text = "x" + conM.ToString();
            conV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            conT.text = diceValFin.ToString();


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            inteM = 0.1f + diceValFin / 10f;
            inteMt.text = "x" + inteM.ToString();
            inteV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            inteT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            strM = 0.1f + diceValFin / 10f;
            strMt.text = "x" + strM.ToString();
            strV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            strT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            dexM = 0.1f + diceValFin / 10f;
            dexMt.text = "x" + dexM.ToString();
            dexV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            dexT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            wisM = 0.8f + ((diceValFin / 10f) * 0.5f);
            wisMt.text = "x" + wisM.ToString();
            wisV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            wisT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            chaM = 0.1f + diceValFin / 10f;
            chaMt.text = "x" + chaM.ToString();
            chaV.text = diceVal1.ToString() + "  +  " + diceVal2.ToString() + "  +  " + diceVal3.ToString();
            chaT.text = diceValFin.ToString();



        }


        if (conM <= 1)
        {
            conMt.color = Color.red;
            conT.color = Color.red;
        }
        if (inteM <= 1)
        {
            inteMt.color = Color.red;
            inteT.color = Color.red;
        }
        if (strM <= 1)
        {
            strMt.color = Color.red;
            strT.color = Color.red;
        }
        if (dexM <= 1)
        {
            dexMt.color = Color.red;
            dexT.color = Color.red;
        }
        if (wisM <= 1)
        {
            wisMt.color = Color.red;
            wisT.color = Color.red;
        }
        if (chaM <= 1)
        {
            chaMt.color = Color.red;
            chaT.color = Color.red;
        }


    }

    void RollEnemyStats()
    {
        

        diceVal1 = Random.Range(diceMin, diceMax);
        EconM = 0.5f + (diceVal1 / 10f);
        enemyConM.text = "x" + EconM.ToString();
        enemyConT.text = diceVal1.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EinteM = 0.5f + diceVal1 / 10f;
        enemyInteM.text = "x" + EinteM.ToString();
        enemyInteT.text = diceVal1.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EstrM = 0.5f + diceVal1 / 10f;
        enemyStrM.text = "x" + EstrM.ToString();
        enemyStrT.text = diceVal1.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EdexM = 0.5f + diceVal1 / 10f;
        enemyDexM.text = "x" + EdexM.ToString();
        enemyDexT.text = diceVal1.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EwisM = 0.5f + diceVal1 / 10f;
        enemyWisM.text = "x" + EwisM.ToString();
        enemyWisT.text = diceVal1.ToString();

        diceVal1 = Random.Range(diceMin, diceMax);
        EchaM = 0.5f + diceVal1 / 10f;
        enemyChaM.text = "x" + EchaM.ToString();
        enemyChaT.text = diceVal1.ToString();

    }

    void FillStats()
    {




            conMt.text = "x" + conM.ToString();
            conT.text = Mathf.RoundToInt((conM - 0.1f) * 10).ToString() ;

            
            inteMt.text = "x" + inteM.ToString();
            inteT.text = Mathf.RoundToInt((inteM - 0.1f) * 10).ToString();


            strMt.text = "x" + strM.ToString();
            strT.text = Mathf.RoundToInt((strM - 0.1f) * 10).ToString();


            dexMt.text = "x" + dexM.ToString();
            dexT.text = Mathf.RoundToInt((dexM - 0.1f) * 10).ToString();


            wisMt.text = "x" + wisM.ToString();
            wisT.text = Mathf.RoundToInt(((wisM -0.8f) * 2) * 10).ToString();


            chaMt.text = "x" + chaM.ToString();
            chaT.text = Mathf.RoundToInt((chaM - 0.1f) * 10).ToString();






        enemyConM.text = "x" + EconM.ToString();
        enemyConT.text = ((EconM - 0.5f) * 10).ToString();

        enemyInteM.text = "x" + EinteM.ToString();
        enemyInteT.text = ((EinteM - 0.5f) * 10).ToString();

        enemyStrM.text = "x" + EstrM.ToString();
        enemyStrT.text = ((EstrM - 0.5f) * 10).ToString();

        enemyDexM.text = "x" + EdexM.ToString();
        enemyDexT.text = ((EdexM - 0.5f) * 10).ToString();

        enemyWisM.text = "x" + EwisM.ToString();
        enemyWisT.text = ((EwisM - 0.5f) * 10).ToString();

        enemyChaM.text = "x" + EchaM.ToString();
        enemyChaT.text = ((EchaM - 0.5f) * 10).ToString();


        if (conM <= 1)
        {
            conMt.color = Color.red;
            conT.color = Color.red;
        }
        else
        {
            conMt.color = Color.green;
            conT.color = Color.blue;
        }
        if (inteM <= 1)
        {
            inteMt.color = Color.red;
            inteT.color = Color.red;
        }
        else
        {
            inteMt.color = Color.green;
            inteT.color = Color.blue;
        }
        if (strM <= 1)
        {
            strMt.color = Color.red;
            strT.color = Color.red;
        }
        else
        {
            strMt.color = Color.green;
            strT.color = Color.blue;
        }
        if (dexM <= 1)
        {
            dexMt.color = Color.red;
            dexT.color = Color.red;
        }
        else
        {
            dexMt.color = Color.green;
            dexT.color = Color.blue;
        }
        if (wisM <= 1)
        {
            wisMt.color = Color.red;
            wisT.color = Color.red;
        }
        else
        {
            wisMt.color = Color.green;
            wisT.color = Color.blue;
        }
        if (chaM <= 1)
        {
            chaMt.color = Color.red;
            chaT.color = Color.red;
        }
        else
        {
            chaMt.color = Color.green;
            chaT.color = Color.blue;
        }





    }


    void ReRollStats()
    {

        curCombo = WorldInteraction.currentcombo;

        if (curCombo < 50)
        {


            diceVal1 = Random.Range(diceMin, diceMax);
            conM = 0.1f + diceVal1 / 10f;
            conMt.text = "x" + conM.ToString();
            conT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            inteM = 0.1f + diceVal1 / 10f;
            inteMt.text = "x" + inteM.ToString();
            inteT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            strM = 0.1f + diceVal1 / 10f;
            strMt.text = "x" + strM.ToString();
            strT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            dexM = 0.1f + diceVal1 / 10f;
            dexMt.text = "x" + dexM.ToString();
            dexT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            wisM = 0.8f + ((diceVal1 / 10f) * 0.5f);
            wisMt.text = "x" + wisM.ToString();
            wisT.text = diceVal1.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            chaM = 0.1f + diceVal1 / 10f;
            chaMt.text = "x" + chaM.ToString();
            chaT.text = diceVal1.ToString();




        }
        else if (curCombo < 100)
        {
            


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            conM = 0.1f + diceValFin / 10f;
            conMt.text = "x" + conM.ToString();
            conT.text = diceValFin.ToString();


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            inteM = 0.1f + diceValFin / 10f;
            inteMt.text = "x" + inteM.ToString();
            inteT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            strM = 0.1f + diceValFin / 10f;
            strMt.text = "x" + strM.ToString();
            strT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            dexM = 0.1f + diceValFin / 10f;
            dexMt.text = "x" + dexM.ToString();
            dexT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            wisM = 0.8f + ((diceVal1 / 10f) * 0.5f);
            wisMt.text = "x" + wisM.ToString();
            wisT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2;
            chaM = 0.1f + diceValFin / 10f;
            chaMt.text = "x" + chaM.ToString();
            chaT.text = diceValFin.ToString();


        }
        else
        {
            


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            conM = 0.1f + diceValFin / 10f;
            conMt.text = "x" + conM.ToString();
            conT.text = diceValFin.ToString();


            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            inteM = 0.1f + diceValFin / 10f;
            inteMt.text = "x" + inteM.ToString();
            inteT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            strM = 0.1f + diceValFin / 10f;
            strMt.text = "x" + strM.ToString();
            strT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            dexM = 0.1f + diceValFin / 10f;
            dexMt.text = "x" + dexM.ToString();
            dexT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            wisM = 0.8f + ((diceValFin / 10f) * 0.5f);
            wisMt.text = "x" + wisM.ToString();
            wisT.text = diceValFin.ToString();

            diceVal1 = Random.Range(diceMin, diceMax);
            diceVal2 = Random.Range(diceMin, diceMax);
            diceVal3 = Random.Range(diceMin, diceMax);
            diceValFin = diceVal1 + diceVal2 + diceVal3;
            chaM = 0.1f + diceValFin / 10f;
            chaMt.text = "x" + chaM.ToString();
            chaT.text = diceValFin.ToString();



        }


        if (conM <= 1)
        {
            conMt.color = Color.red;
            conT.color = Color.red;
        }
        else
        {
            conMt.color = Color.green;
            conT.color = Color.blue;
        }
        if (inteM <= 1)
        {
            inteMt.color = Color.red;
            inteT.color = Color.red;
        }
        else
        {
            inteMt.color = Color.green;
            inteT.color = Color.blue;
        }
        if (strM <= 1)
        {
            strMt.color = Color.red;
            strT.color = Color.red;
        }
        else
        {
            strMt.color = Color.green;
            strT.color = Color.blue;
        }
        if (dexM <= 1)
        {
            dexMt.color = Color.red;
            dexT.color = Color.red;
        }
        else
        {
            dexMt.color = Color.green;
            dexT.color = Color.blue;
        }
        if (wisM <= 1)
        {
            wisMt.color = Color.red;
            wisT.color = Color.red;
        }
        else
        {
            wisMt.color = Color.green;
            wisT.color = Color.blue;
        }
        if (chaM <= 1)
        {
            chaMt.color = Color.red;
            chaT.color = Color.red;
        }
        else
        {
            chaMt.color = Color.green;
            chaT.color = Color.blue;
        }

        PlayerMovement.speed *= dexM;
        PlayerAttack.wisMod = wisM;
        PlayerAttack.chaMod = chaM;
        BasicProjectile.damage *= inteM;
        BounceProjectile.damage *= inteM;
        fireBall.damage *= inteM;
        RailgunProjectile.damage *= inteM;
        ShockWave.damage *= inteM;
        DodgeDamage.damage *= strM;
        meleeSwing.damage *= strM;

    }

    public void Continue()
    {
        SceneManager.LoadScene(WorldInteraction.nextSceneIndex);
    }


}
