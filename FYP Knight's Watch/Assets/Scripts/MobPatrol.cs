using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPatrol : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float distance;
    private bool mRight = true;

    public int health;
    

    private float dazedTime;
    public float startDazedTime;

    public Transform groundDetect;

    void Update()
    {
        if (dazedTime <= 0)
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
            animator.SetBool("Death", true);
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator.SetFloat("Speed", speed);

        RaycastHit2D ground = Physics2D.Raycast(groundDetect.position, Vector2.down, distance);
        if (ground.collider == false)
        {
            if(mRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                mRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                mRight = true;
            }
        }


    }

    public void DamageTaken(int damage)
    {
        
        dazedTime = startDazedTime;
        health -= damage;
        animator.SetTrigger("Hit");
        // Debug.Log("damage Taken");

    }

    public void DamageTaken2(int damage2)
    {
        dazedTime = startDazedTime;
        health -= damage2;
        //animator.SetTrigger("Hit");
       // Debug.Log("damage Taken");
        
    }

    
}
