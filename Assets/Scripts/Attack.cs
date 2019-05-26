using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class in charge of allowing it's gameobject to attack.
/// \
/// That is to say, spawn AttackObjects.
/// </summary>
public class Attack : MonoBehaviour
{

    [SerializeField] bool playerControlled;
    [SerializeField] bool rangedAttack;
    [SerializeField] GameObject attackPrefab;

    [SerializeField] float damage;
    [SerializeField] float reach;
    [SerializeField] float reachSpeed;

    [SerializeField] float attackCooldown;

    [SerializeField] float timeBeforeDestruct;
    float currCooldown;
    Army armyScript;

    [SerializeField] float attackFreeze;
    float currAtkfrz;
    float m;


    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        armyScript = GetComponent<Army>();
        currCooldown = 0;
        rb = GetComponent<Rigidbody2D>();
        currAtkfrz = attackFreeze;
        if(GetComponent<Player>() != null)
        {

            m = GetComponent<Player>().moveS;

        }

        else if (GetComponent<Enemy>() != null)
        {
            m = GetComponent<Enemy>().speed;

        }
        

    }

    // Update is called once per frame
    void Update()
    {

        currCooldown += Time.deltaTime;
        currAtkfrz += Time.deltaTime;

        if (Input.GetAxis("Fire1") > 0 && currCooldown >= attackCooldown && playerControlled )
        {
            Strike(GetComponent<Player>());
        }

        if (GameObject.FindGameObjectWithTag("Player"))
        {

            if (currAtkfrz < attackFreeze)
            {

                GetComponent<Player>().moveS = 0;
                GetComponent<Enemy>().speed = 0;
            }
            else
            {
                GetComponent<Player>().moveS = m;
                GetComponent<Enemy>().speed = m;
            }
        }
    }

    /// <summary>
    /// Spawn an attack object with the current stats, given by the current
    /// formation.
    /// </summary>
    /// <param name="agent">If what is spawning it is a player or enemy, gotten trough what script is has.</param>
    /// <param name="agressiveModifier">A modifier to add to the damage</param>
    public void Strike(MonoBehaviour agent, float agressiveModifier)
    {
        
        GameObject instantiatedObject = Instantiate(attackPrefab, transform.position, transform.rotation);

        var b = instantiatedObject.GetComponentInChildren<AttackObject>();
        b.dmg = damage + (int)agressiveModifier;
        b.lifeTime = reach;
        b.reachSpd = reachSpeed;
        b.isProjectile = rangedAttack;
        b.origin = transform.position;
        b.timeBeforeDestruct = this.timeBeforeDestruct;
        b.creator = this.gameObject;
        instantiatedObject.GetComponent<Rigidbody2D>().rotation = 0;

        currCooldown = 0;
        currAtkfrz = 0;

        // Todo refactor this to us inheritance pls
        if (agent as Player != null)
            m = GetComponent<Player>().moveS;
        else if (agent as Enemy != null)
            m = GetComponent<Enemy>().speed;
    }

/// <summary>
    /// Spawn an attack object with the current stats, given by the current
    /// formation.
    /// </summary>
    /// <param name="agent">If what is spawning it is a player or enemy, gotten trough what script is has.</param>
    public void Strike(MonoBehaviour agent)
    {

        GameObject instantiatedObject = Instantiate(attackPrefab, transform.position, transform.rotation);

        var b = instantiatedObject.GetComponentInChildren<AttackObject>();
        b.dmg = damage;
        b.lifeTime = reach;
        b.reachSpd = reachSpeed;
        b.isProjectile = rangedAttack;
        b.origin = transform.position;
        b.timeBeforeDestruct = this.timeBeforeDestruct;
        b.creator = this.gameObject;
        instantiatedObject.GetComponent<Rigidbody2D>().rotation = 0;

        currCooldown = 0;
        currAtkfrz = 0;

        // Todo refactor this to us inheritance pls
        if (agent as Player != null)
            m = GetComponent<Player>().moveS;
        else if (agent as Enemy != null)
            m = GetComponent<Enemy>().speed;
    }



}

