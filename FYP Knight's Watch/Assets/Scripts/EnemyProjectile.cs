//Reference - https://www.youtube.com/watch?v=_Z1t7MNk0c4&list=PLBIb_auVtBwDgHLhYc-NG633rTbTPim9z&index=2
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed;

    private Transform player;
    private Vector2 target;
    
    public int damage;
    public LayerMask whatIsEnemies;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            
            
            DestroyProjectile();
        }
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<KnightHealth>().TakeDamage(damage);
           // Destroy(gameObject);
        }
        else if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
