using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPart2 : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;
    public GameObject[] spawners;
    private int spawnerIndex = 0;

    public GameObject player;

    private float stageCount = 0;

    private bool twoPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < popUps.Length; i++)
            popUps[i].SetActive(false);

        popUps[popUpIndex].SetActive(true);

        player.GetComponentInChildren<PlayerAttack>().disableBounce = true;
        player.GetComponentInChildren<PlayerAttack>().disableFireball = true;
        player.GetComponentInChildren<PlayerAttack>().disableWish = true;

        // Pause combo effects
        player.GetComponent<ComboManager>().pauseComboEffects = true;
        player.GetComponent<ComboManager>().playerCombo = 100;

    }

    // Update is called once per frame
    void Update()
    {
        // Stats
        if (popUpIndex == 0)
        {
            stageCount += Time.deltaTime;

            if (stageCount >= 3)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);

                stageCount = 0;
            }
        }
        else if (popUpIndex == 1)
        {
            stageCount += Time.deltaTime;

            if (stageCount >= 3)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);

                stageCount = 0;
            }
        }
        else if (popUpIndex == 2)
        {
            stageCount += Time.deltaTime;

            if (stageCount >= 3)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);

                stageCount = 0;
            }
        }
        else if (popUpIndex == 3)
        {
            stageCount += Time.deltaTime;

            if (stageCount >= 3)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);

                stageCount = 0;

                spawners[spawnerIndex].SetActive(true);
                player.GetComponentInChildren<PlayerAttack>().disableBounce = false;
            }
        }

        // Bounce ball
        else if (popUpIndex == 4)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);
            }
        }
        else if (popUpIndex == 5)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);

                player.GetComponentInChildren<PlayerAttack>().disableFireball = false;
            }
        }

        // Fireball
        else if (popUpIndex == 6)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // If released
                if (twoPressed)
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

                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);

                    player.GetComponentInChildren<PlayerAttack>().disableWish = false;
                }
                else
                {
                    twoPressed = true;
                }
            }
        }

        //Wish
        else if (popUpIndex == 7)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);
            }
        }
        if (popUpIndex == 8)
        {
            stageCount += Time.deltaTime;

            if (stageCount >= 3)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);

                stageCount = 0;

                spawners[spawnerIndex].SetActive(true);

                player.GetComponent<ComboManager>().pauseComboEffects = false;
                player.GetComponent<ComboManager>().playerCombo = 0;
            }
        }

        //Final boss
        else if (popUpIndex == 9)
        {
            stageCount += Time.deltaTime;
            if (stageCount >= 5)
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
