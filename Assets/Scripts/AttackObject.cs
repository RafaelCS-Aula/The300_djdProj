using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script in charge of controlling the prefab used as the attack.
/// \
/// It has its stats gained from the Attack script on instantiation and detects
/// the collisions.
/// </summary>
public class AttackObject : MonoBehaviour
{


    private Rigidbody2D rb;

    
    [HideInInspector]
    public float dmg, lifeTime, reachSpd, timeBeforeDestruct;

    
    public bool isProjectile;

    
    [HideInInspector]
    public Vector3 origin;

    [HideInInspector]
    public GameObject creator;
    

    float dist = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
       // AttackStats = GetComponentInParent<Attack>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If it isnt a projectile then it will go straight ahead.
        if(!isProjectile)
        {

            dist ++;

            if (dist < lifeTime)
            {

               rb.velocity = transform.right * reachSpd;
              
               
            }
            else if (dist >= lifeTime)
                timeBeforeDestruct --;

            if (timeBeforeDestruct <= 0)
            {
                Destroy(gameObject);
                dist = 0;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        

        if (collision.gameObject.tag != creator.gameObject.tag)
        {

            collision.gameObject.GetComponent<Army>().TakeDamage(dmg);            
            Destroy(this.gameObject);
        }
    }



}
