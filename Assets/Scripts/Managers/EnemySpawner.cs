using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles sthe spawning of the 3 enemy types
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1, enemy2, enemy3;
    GameObject enemyToSpawn;
    
    [HideInInspector] public GameObject lastSpawnedEnemy;
    [HideInInspector] public GameObject playerObjectReference;    
    

    public float spawnRate = 2f;
    float nextSpawn = 0f;
    int whatToSpawn;

    private void Update()
    {
        if (Time.time >nextSpawn)
        {
            whatToSpawn = Random.Range(1, 6);
            //Debug.Log(whatToSpawn);

            switch (whatToSpawn)
            {
                case 1:
                    enemyToSpawn = enemy1;
                    break;

                case 2:
                    enemyToSpawn = enemy2;
                    break;

                case 3:
                    enemyToSpawn = enemy3;
                    break;
            }

            lastSpawnedEnemy = 
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            lastSpawnedEnemy.GetComponent<EnemyControl>().playerReference = 
            playerObjectReference;

            

            nextSpawn = Time.time + spawnRate;
        }
    }
}
