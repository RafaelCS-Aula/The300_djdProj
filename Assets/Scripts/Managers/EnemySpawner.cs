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
            whatToSpawn = Random.Range(0, 6);
            //Debug.Log(whatToSpawn);

            switch (whatToSpawn)
            {
                case 0:
                    lastSpawnedEnemy = Instantiate(enemy1, transform.position, Quaternion.identity);
                    break;

                case 1:
                    lastSpawnedEnemy = Instantiate(enemy2, transform.position, Quaternion.identity);
                    break;

                default:
                    lastSpawnedEnemy = Instantiate(enemy3, transform.position, Quaternion.identity);
                    break;
            }

            lastSpawnedEnemy.GetComponent<EnemyControl>().playerReference = FindObjectOfType<PlayerControl>().gameObject;

            nextSpawn = Time.time + spawnRate;
        }
    }
}
