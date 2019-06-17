using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class that controls what formation / and attack the standart enemy uses.
/// \
/// Utilizes weighted chance algorith to decide formations
/// \
/// And a basic comparison between 2 random integers to determine when to attack
/// </summary>
class EnemyControl : Controller
{
    float timer = 0;
    [SerializeField]
    float minDistanceToCharge;
    [SerializeField]
    float minDistanceToBrace;
    [SerializeField]
    float chanceToDoNothing;

    float distanceToPlayer;

    [HideInInspector]
    public float agressiveMod = 0.5f;

    [HideInInspector]
    public GameObject playerReference = null;

    float chanceToBrace;
    float chanceToCharge;

    List<float> chanceList = new List<float>();

    private void Start() 
    {
        // Usefull for testing
     if(playerReference == null) playerReference = GameObject.FindGameObjectWithTag("Player");   
    }
    public override Formation ChooseFormation()
    {
        

        // We multiply by -1 because 
        distanceToPlayer = 
        Mathf.Abs(playerReference.transform.position.x - transform.position.x);

        Debug.Log(distanceToPlayer);
        

        chanceToCharge = Mathf.Clamp(chanceToCharge, 0, 1);
        chanceToBrace = Mathf.Clamp(chanceToBrace, 0, 1);

        if (brace != null) CalculateChanceToBrace();
        if (charge != null) CalculateChanceToCharge();
        return CalculateNextState();
    }

    void CalculateChanceToBrace()
    {
        // Enemy braces sooner if less agressive
        float md = minDistanceToBrace * (1 + agressiveMod);

        // Gives a bonus to the chance to Brace based on how close 
        // from the player the army is
        if (distanceToPlayer < md)
        {
            // very big chance to Brace
            if (distanceToPlayer > 0) chanceToBrace = (1 / distanceToPlayer);
            else chanceToBrace = 1000.0f;
        }
        else chanceToBrace = 0;

    }

    void CalculateChanceToCharge()
    {

        chanceList.Clear();
        
        // Enemy charges earlier if more agressive
        float md = minDistanceToCharge * agressiveMod;

        // Gives a bonus to the chance to charge based on how far 
        // away from the player the army is
        if (distanceToPlayer > md)
        {
            chanceToCharge = distanceToPlayer * 0.01f;
        }
        else chanceToCharge = 0;
    }

    Formation CalculateNextState()
    {
        /*// Calculates chance to attack, stops the army to do so
        if(armyScript.enemiesInRange.Count > 0)
        {
            float a = Random.Range(0, 1);
            float b = Random.Range(0, 1);

            if(a > b) armyScript.Attack();
            return armyScript.activeFormation;
        }

        float sum = 0.0f;


        // REMINDER:
        // chanceList has 1 more value than possibleStates, this is the chance 
        // that the enemy will not change his state.
        if (charge != null) chanceList.Add(chanceToCharge);
        if (brace != null) chanceList.Add(chanceToBrace);


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
        chanceList.Add(sum * chanceToDoNothing);
        sum += chanceToDoNothing;


        // Weighted chance
        float r = Random.Range(0, sum);

        // this part is to calculate whether there will be
        // a change in the formation at all
        if (r < chanceList[chanceList.Count - 1])
        {
            return armyScript.activeFormation;
        }

        sum -= chanceList[chanceList.Count - 1];
        chanceList.RemoveAt(chanceList.Count - 1);


        r = Random.Range(0, sum);


        for (int i = 0; i < chanceList.Count; i++)
        {
            if (r < chanceList[i])
            {
                return possibleFormations[i];
          
            }

            sum -= chanceList[i];
        }*/

        float NextState = Random.Range(0, 100);
        if (NextState > 90 && timer > 0.2)
        {
            timer = 0;
            Formation f = possibleFormations[Random.Range(0, possibleFormations.Count)];
            if (f.Designation == EnumArmyFormations.Attack)
                armyScript.Attack();
            return f;
        }
        // by default just don´t change formation

        return armyScript.activeFormation;

    }

    protected  override void Update()
    {
        base.Update();

        timer += Time.deltaTime;
    }
}
