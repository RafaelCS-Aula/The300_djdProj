using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles sthe spawning of the 3 enemy types
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1, enemy2, enemy3;

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
                    Instantiate(enemy1, transform.position, Quaternion.identity);
                    break;

                case 2:
                    Instantiate(enemy2, transform.position, Quaternion.identity);
                    break;

                case 3:
                    Instantiate(enemy3, transform.position, Quaternion.identity);
                    break;
            }

            nextSpawn = Time.time + spawnRate;
        }
    }
}
