using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base control for each "army" on in the game-
/// \
/// Hold information like number of troops (hp), modifiers 
/// speed, mass and attack power.
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(Followers))]
public class Army : MonoBehaviour
{
    [HideInInspector] public bool isAttacking = false;
    Rigidbody2D myRb;
    Followers followerScript;
    public List<GameObject> enemiesInRange = new List<GameObject>();
    Vector3 movementVect = new Vector3(0,0,0);

    // Stats
    public int nTroops;
    public float attack;
    public float defense;
    public float speed;
    public float mass;

    // Cooldown
    [SerializeField] float attackCooldown = 1.0f;
    private float atkCooldownTimer = 0;

    // Knockback vars
    float knockbackTimer;
    float knockbackSpeed;

    // Acess this variable if you need to know what formation is the current one
    [HideInInspector]
    public Formation activeFormation;

    // Formation Modifiers
    [HideInInspector]
    public float defenseModifier
    {
        get { return activeFormation.DefenseModifier; }
    }

    [HideInInspector]
    public float attackModifier
    {
        get { return activeFormation.AttackModifier; }
    }

    [HideInInspector]
    public float massModifier
    {
        get { return activeFormation.MassModifier; }
    }

    [HideInInspector]
    public float speedModifier
    {
        get { return activeFormation.SpeedModifier; }
    }


    private void Awake() 
    {
        myRb = GetComponent<Rigidbody2D>();   
        followerScript = GetComponent<Followers>(); 
        followerScript.aScript = this;
    }

    private void Update() 
    {
        if(atkCooldownTimer < attackCooldown) isAttacking = false;
        atkCooldownTimer += Time.deltaTime;    
    }
    private void FixedUpdate()
    {
        myRb.mass = this.mass * massModifier;

        if (knockbackTimer > 0)
        {
            knockbackTimer -= Time.deltaTime;
            movementVect.x = knockbackSpeed;
        }
        else
        {
            movementVect.x = speed * speedModifier;
        }        

        myRb.velocity = movementVect;
        
        if (nTroops <= 0)
        {
            // Lose
            Destroy(gameObject);
        }
    }


    public void TakeDamage(float damage)
    {
        if (damage > defense * defenseModifier)
        {
        
            nTroops -= (int)(damage);
            // Updates how many guys are following the main object
            
            followerScript.UpdateFollowers(nTroops);
        }

        // knockback
        

        knockbackSpeed = transform.right.x * damage / mass;

        knockbackTimer = 0.125f;

    }

    public void Attack()
    {
        if(atkCooldownTimer >= attackCooldown)
        {
            isAttacking = true;
            foreach(GameObject g in enemiesInRange)
            {
                if(g.GetComponent<Army>()) 
                {
                    g.GetComponent<Army>().TakeDamage(attack *  attackModifier);
                }


            }

            atkCooldownTimer = 0.0f;

        }
        
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (!other.isTrigger && other.gameObject.GetComponent<Army>())
        {
            // Debug.Log($"Hello {other.gameObject}");
            enemiesInRange.Add(other.gameObject);
        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log($"begone {other.gameObject}");
        if (enemiesInRange.Contains(other.gameObject) && !other.isTrigger)
            enemiesInRange.Remove(other.gameObject);


        
    }







}
