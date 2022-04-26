using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    public Animator animator;
    public Animator camAnim;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPosition;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public int damage2;
    

    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                
                animator.SetTrigger("Attack1");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehaviour>().DamageTaken(damage);
                }
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {

                animator.SetTrigger("Attack2");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehaviour>().DamageTaken2(damage2);
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
