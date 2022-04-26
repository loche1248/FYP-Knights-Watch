using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float speed;
    public Animator animator;
    public int health;

    private float dazedTime;
    public float startDazedTime;


    

    // Update is called once per frame
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
            // animator.SetBool("Death", true);
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
}
