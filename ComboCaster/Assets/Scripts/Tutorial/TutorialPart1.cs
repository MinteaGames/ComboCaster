using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPart1 : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;
    public GameObject[] spawners;
    private int spawnerIndex = 0;

    public GameObject player;

    private float stage4Count = 0;
    private float stage5Count = 0;
    private float stage8Count = 0;
    private float stage9Count = 0;

    private bool ePressed = false;
    private bool qPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < popUps.Length; i++)
                popUps[i].SetActive(false);

        popUps[popUpIndex].SetActive(true);

        disableAllAbilities();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerAbilities>().paused == false)
        {


            //Movement
            if (popUpIndex == 0)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                }

            }
            //Magic missile
            else if (popUpIndex == 1)
            {
                player.GetComponentInChildren<PlayerAttack>().disableMagicMissile = false;

                spawners[spawnerIndex].SetActive(true);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                }
            }
            // Melee
            else if (popUpIndex == 2)
            {
                player.GetComponentInChildren<PlayerAttack>().disableMelee = false;

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                }
            }
            // Dodge
            else if (popUpIndex == 3)
            {
                player.GetComponent<PlayerAbilities>().disableDash = false;

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    spawners[spawnerIndex].SetActive(false);
                    spawnerIndex++;

                    // Wipe room
                    GameObject[] enemies;
                    enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in enemies)
                    {
                        Destroy(enemy);
                    }

                    // Pause combo effects
                    player.GetComponent<ComboManager>().pauseComboEffects = true;
                    if (player.GetComponent<ComboManager>().playerCombo < 15)
                    {
                        player.GetComponent<ComboManager>().playerCombo = 15;
                    }

                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                }
            }
            // Introduce combo 
            else if (popUpIndex == 4)
            {
                stage4Count += Time.deltaTime;
                if (stage4Count >= 3)
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                }
            }
            else if (popUpIndex == 5)
            {
                stage5Count += Time.deltaTime;
                if (stage5Count >= 3)
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                }
            }
            // Railgun
            else if (popUpIndex == 6)
            {
                spawners[spawnerIndex].SetActive(true);

                disableAllAbilities();
                player.GetComponentInChildren<PlayerAttack>().disableRailgun = false;


                // Disable all attacks besides Railgun

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ePressed = true;
                }


                GameObject[] enemies;
                enemies = GameObject.FindGameObjectsWithTag("Enemy");

                if (enemies.Length == 0 && ePressed == true)
                {
                    spawners[spawnerIndex].SetActive(false);
                    spawnerIndex++;

                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                }
            }
            //Shockwave
            else if (popUpIndex == 7)
            {
                spawners[spawnerIndex].SetActive(true);

                // Disable all attacks besides Shockwave
                disableAllAbilities();
                player.GetComponentInChildren<PlayerAttack>().disableShock = false;

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    qPressed = true;
                }

                if (qPressed == true)
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);

                    player.GetComponent<ComboManager>().pauseComboEffects = false;
                    // Enable all known attacks
                }
            }
            // Complete level with whats known
            else if (popUpIndex == 8)
            {
                player.GetComponent<PlayerAbilities>().disableDash = false;
                player.GetComponentInChildren<PlayerAttack>().disableMagicMissile = false;
                player.GetComponentInChildren<PlayerAttack>().disableRailgun = false;
                player.GetComponentInChildren<PlayerAttack>().disableMelee = false;
                player.GetComponentInChildren<PlayerAttack>().disableShock = false;


                stage8Count += Time.deltaTime;
                if (stage8Count >= 5)
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                }
            }
            else if (popUpIndex == 9)
            {
                stage9Count += Time.deltaTime;
                if (stage9Count >= 5)
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 10)
            {
                GameObject[] enemies;
                enemies = GameObject.FindGameObjectsWithTag("Enemy");

                if (enemies.Length == 0 && spawners[spawnerIndex].GetComponent<spawnEnemies>().enemiesLeftToSpawn <= 0)
                {
                    popUps[popUpIndex].SetActive(true);
                }
            }
        }
    }

    void disableAllAbilities()
    {
        player.GetComponent<PlayerAbilities>().disableDash = true;
        player.GetComponentInChildren<PlayerAttack>().disableMagicMissile = true;
        player.GetComponentInChildren<PlayerAttack>().disableRailgun = true;
        player.GetComponentInChildren<PlayerAttack>().disableMelee = true;
        player.GetComponentInChildren<PlayerAttack>().disableBounce = true;
        player.GetComponentInChildren<PlayerAttack>().disableShock = true;
        player.GetComponentInChildren<PlayerAttack>().disableFireball = true;
        player.GetComponentInChildren<PlayerAttack>().disableWish = true;
    }
}
