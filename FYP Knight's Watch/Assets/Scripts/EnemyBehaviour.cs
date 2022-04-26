using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private bool mRight = true;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;


    public int health;

    private float dazedTime;
    public float startDazedTime;


    public Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    

    void Update()
    {
        if(dazedTime <= 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            // animator.SetBool("Death", true);
        }

        
        

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        Flip();

        if (timeBtwShots <= 0)
        {
            animator.SetTrigger("Attack");
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    public void DamageTaken(int damage)
    {

        dazedTime = startDazedTime;
        health -= damage;
        // animator.SetTrigger("Hit");
        // Debug.Log("damage Taken");

    }

    public void DamageTaken2(int damage2)
    {
        dazedTime = startDazedTime;
        health -= damage2;
        //animator.SetTrigger("Hit");
        // Debug.Log("damage Taken");

    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > player.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }

}