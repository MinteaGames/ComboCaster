using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public int numGoblinsToSpawn;
    int goblinsLeftToSpawn;
    public GameObject goblinPrefab;

    public Transform[] spawnLocations;
    public float spawnDelay;
    float spawnDelayTime;


    public GameObject endPortal;
    GameObject[] enemiesOnField;
    void Start()
    {
        spawnDelayTime = spawnDelay;
        goblinsLeftToSpawn = numGoblinsToSpawn;
        endPortal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (goblinsLeftToSpawn >0)
        {
            if (spawnDelayTime <= spawnDelay)
            {
                spawnDelayTime += Time.deltaTime;
            }
            else
            {
                spawnDelayTime = 0;
                int randomPos = Random.Range(0, spawnLocations.Length);
                GameObject newGoblin = Instantiate(goblinPrefab, spawnLocations[randomPos].position, transform.rotation);
                newGoblin.GetComponent<EnemyHealth>().health = 3;
                newGoblin.GetComponent<enemyScore>().enemyBaseScore = 5;
                goblinsLeftToSpawn--;
            }
        }

        enemiesOnField = GameObject.FindGameObjectsWithTag("Enemy");
        if ((enemiesOnField.Length == 0) &&( goblinsLeftToSpawn == 0))
        {
            endPortal.SetActive(true);
        }
    }

}
