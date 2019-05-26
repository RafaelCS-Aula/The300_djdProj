using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base control for each "army" on in the game-
/// \
/// Hold information like number of troops (hp), modifiers 
/// speed, mass and attack power.
/// </summary>
public class Army : MonoBehaviour
{

    [SerializeField]
    GameObject Lose;

    Player player;


    public EnumArmyStates currentState;
    public int nTroops;

    [HideInInspector]
    public float speedModifier = 1;

    
    public float damagePenalty;

    [HideInInspector]
    public float defenseModifier;
    [HideInInspector]
    public float attackModifier;
    
    [HideInInspector]
    public float massModifier;

    [HideInInspector]
    public float defense;

    private void Update()
    {

        GetComponent<Rigidbody2D>().mass *= massModifier;


        if (nTroops <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void TakeDamage(float damage)
    {
        if (damage > defense * defenseModifier)
        {
            if (GetComponent<EnemyBehaviour>() != null)
            {
                // Enemies will get less agressive after being hurt, 
                GetComponent<EnemyBehaviour>().agressiveMod -= damagePenalty;

            }
        
            nTroops -= (int)damage;
            player.TroopsTxt -= (int)damage;
            
            // Updates how many guys are following the main object
            GetComponent<Followers>().UpdateFollowers(nTroops);
        }

        //                GAMEOVER

        if (nTroops >= 0 && GameObject.FindGameObjectWithTag("Player"))
        {
            Lose.SetActive(true);
        }

    }
}
