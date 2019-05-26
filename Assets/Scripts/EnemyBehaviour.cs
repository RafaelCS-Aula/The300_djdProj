using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager to make enemies decide what formation they will use.
/// </summary>
public class EnemyBehaviour : MonoBehaviour
{
    

    [SerializeField]
    float minDistanceToCharge;
    [SerializeField]
    float minDistanceToBrace;
    [SerializeField]
    float minDistanceToAttack;

    [SerializeField]
    float chanceToDoNothing;

    float distanceToPlayer;

    [HideInInspector]
    public float agressiveMod = 0.5f;

    float chanceToBrace;
    float chanceToCharge;
    


    Formation[] possibleStates;

    float[] chanceList;


    GameObject playerArmy;

    Attack atkScript;

    private void Awake()
    {
        // Gets all components who inherit from the Formation class
        possibleStates = GetComponents<Formation>();
        
    }
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Fuck");
        atkScript = GetComponent<Attack>();
        playerArmy = GameObject.FindGameObjectWithTag("Player");
        
        // Tell them they shouldn't care about input
        foreach (Formation p in possibleStates)
        {
            p.SetControllable(false);

        }

        chanceList = new float[possibleStates.Length + 1];
           
    }

    // Update is called once per frame
    void Update()
    {
        
        Mathf.Clamp(chanceToCharge, 0, 1);
        Mathf.Clamp(chanceToBrace, 0, 1);
        Mathf.Clamp(agressiveMod, 0, 1);

        chanceToDoNothing *= agressiveMod;
        
        // Get distance to player
        distanceToPlayer = (playerArmy.transform.position - gameObject.transform.position).magnitude;

        Debug.Log("dist = " + distanceToPlayer);

        CalculateChanceToBrace();
        CalculateChanceToCharge();
        ChanceToAttack();
        

        Formation next = CalculateNextState();
        if (next != null)
            next.ActivateFormation();

        
    }

    void CalculateChanceToCharge()
    {

        // Enemy charges earlier if more agressive
        minDistanceToCharge *= agressiveMod;

         // Gives a bonus to the chance to charge based on how far 
         // away from the player the army is
        if (distanceToPlayer > minDistanceToCharge)
        {
           
            chanceToCharge /= (1 / distanceToPlayer);
            Debug.Log("1/distance to player = " + 1 / distanceToPlayer);

        }
        else
            chanceToCharge *= (1 / distanceToPlayer);

    }

    void CalculateChanceToBrace()
    {
        // Enemy braces sooner if less agressive
        minDistanceToBrace *= 1 + agressiveMod;

         // Gives a bonus to the chance to Brace based on how close 
         // from the player the army is
        if (distanceToPlayer < minDistanceToBrace)
        {
            // very big chance to Brace
            chanceToBrace *= (1 / distanceToPlayer);
        }
        else
            chanceToBrace /= (1 / distanceToPlayer);

    }

    void ChanceToAttack()
    {
        float a = Random.Range(0, agressiveMod);
        float b = Random.Range(0, agressiveMod);

        // When in range there's a chance to attack
        if (distanceToPlayer < minDistanceToAttack)
        {
            if(a <= b) 
            atkScript.Strike(GetComponent<Enemy>(), agressiveMod);
        }

    }

    Formation CalculateNextState()
    {
        float sum = 0.0f;
  

        // REMINDER:
        // chanceList has 1 more value than possibleStates, this is the chance 
        // that the enemy will not change his state.

        for (int i = 0; i < possibleStates.Length; i++)
        {
            if (possibleStates[i] as FCharge != null) chanceList[i + 1] = chanceToCharge;
            if (possibleStates[i] as FBrace != null) chanceList[i + 1] = chanceToBrace;
            // more chances for more formations possible
        }


        // Algorithm for weighted Randomization:
        // Get the sum of all chances, then 
        // get a random number between 0 and it.
        // Subtract the random from each possible chance and if
        // it's smaller then that is the choosen chance.
        foreach (float f in chanceList)
        {
            sum += f;
        }

        // Specific case to get the chance that the army doesnt change formation
        // always a specified percentage of the sum,
        // then put that in the array and add it to the sum.
        chanceList[0] = sum * chanceToDoNothing;
        sum += chanceToDoNothing;

        
        // Weighted chance
        float r = Random.Range(0, sum);

        if (r < chanceList[0])
        {
            return null;
        }

        sum -= chanceList[0];

        for (int i = 1; i < chanceList.Length - 1; i++)
        {
            if (r < chanceList[i])
            {
                return possibleStates[i - 1];

            }

            sum -= chanceList[i];
        }

        return null;

    }
}
