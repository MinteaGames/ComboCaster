using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public int numEnemiesToSpawn;
    public int enemiesLeftToSpawn;
    public GameObject goblinPrefab;
    public GameObject ogrePrefab;
    public GameObject beholderPrefab;

    // For tutorial purposes restrict enemy type
    public bool onlyGoblins = false;
    public bool onlyOgres = false;
    public bool onlyBeholders = false;

    public Transform[] spawnLocations;
    public float spawnDelay;
    float spawnDelayTime;

    int enemySpawn;

    public GameObject endPortal;
    GameObject[] enemiesOnField;
    void Start()
    {
        spawnDelayTime = spawnDelay;
        enemiesLeftToSpawn = numEnemiesToSpawn;
        endPortal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesLeftToSpawn >= 0)
        {
            if (spawnDelayTime <= spawnDelay)
            {
                spawnDelayTime += Time.deltaTime;
            }
            else
            {
                spawnDelayTime = 0;
                int randomPos = Random.Range(0, spawnLocations.Length);

                if (onlyGoblins == true) SpawnGoblin(randomPos);
                else if (onlyOgres == true) SpawnOgre(randomPos); 
                else if (onlyBeholders == true) SpawnBeholder(randomPos);
                else  // If no restrictions pick randomly
                {
                    enemySpawn = Random.Range(0, 10);

                    if (enemySpawn >= 9)
                    {
                        SpawnOgre(randomPos);
                    }
                    else if (enemySpawn >= 8)
                    {
                        SpawnBeholder(randomPos);
                    }
                    else
                    {
                        SpawnGoblin(randomPos);
                    }
                }
                
                enemiesLeftToSpawn--;
            }
        }

        enemiesOnField = GameObject.FindGameObjectsWithTag("Enemy");
        if ((enemiesOnField.Length == 0) &&( enemiesLeftToSpawn == 0))
        {
            endPortal.SetActive(true);
        }
    }

    private void SpawnGoblin(int randomPos)
    {
        GameObject newGoblin = Instantiate(goblinPrefab, spawnLocations[randomPos].position, transform.rotation);
        newGoblin.GetComponent<EnemyHealth>().health = 3;
        newGoblin.GetComponent<enemyScore>().enemyBaseScore = 5;
    }
    private void SpawnOgre(int randomPos)
    {
        GameObject newOgre = Instantiate(ogrePrefab, spawnLocations[randomPos].position, transform.rotation);
        newOgre.GetComponent<EnemyHealth>().health = 8;
        newOgre.GetComponent<enemyScore>().enemyBaseScore = 20;
    }
    private void SpawnBeholder (int randomPos)
    {
        GameObject newBeholder = Instantiate(beholderPrefab, spawnLocations[randomPos].position, transform.rotation);
        newBeholder.GetComponent<EnemyHealth>().health = 5;
        newBeholder.GetComponent<enemyScore>().enemyBaseScore = 15;
    }

}
