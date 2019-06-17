using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Takes care of Winning, losing, spawning the player and 
///  spawner of the enemies
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("Objects that contain the location where the armies will spawn")]
    public GameObject playerSpawn;
    public GameObject enemySpawner;

    [Header("Coordinates that the player must reach to win/ lose respectively")]
    public float WinX;
    public float LoseX;

    [Header("Stuff that gets spawned")]
    public GameObject playerPrefab;


    [Header("Win/Lose Menu")]
    public GameObject winObj;
    public GameObject loseObj;



    private GameObject player;
    private void Awake() 
    {
        if(instance == null) instance = this;
        else if(instance != this) Destroy(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerPrefab, playerSpawn.transform.position, playerSpawn.transform.rotation);
        Camera c = Camera.main;
        c.GetComponent<CameraController>().target = player.transform;
        enemySpawner.GetComponent<EnemySpawner>().playerObjectReference = player;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(player != null)
        {
            if(player.GetComponent<Army>().nTroops <= 0) GameOver();
            if(player.transform.position.x < LoseX) GameOver();


            if(player.transform.position.x > WinX) GameWin();

        }
        else GameOver();


    }

    private void OnDrawGizmos() 
    {

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(playerSpawn.transform.position, 2);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemySpawner.transform.position, 2);
        
    }
    void GameOver()
    {
        loseObj.SetActive(true);
        Time.timeScale = 0f;
        return;
    }

    void GameWin()
    {
        winObj.SetActive(true);
        Time.timeScale = 0f;
        return;
    }
}
