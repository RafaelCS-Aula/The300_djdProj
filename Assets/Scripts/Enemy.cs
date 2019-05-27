using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for armies with Enemy logic.
/// </summary>
public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform target;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime* speed);

            transform.position = new Vector3(transform.position.x, transform.position.y, 0.52f);

            if (gameObject.tag == "Wizard")
            {
                anim.SetFloat("AbsVelocityX", Mathf.Abs(target.position.x * speed));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ded")
        {
            Destroy(gameObject);
        }

    }
}
