//Reference - https://www.youtube.com/watch?v=aoZqeG7rqV0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightHealth : MonoBehaviour
{
    public Animator animator;
    public Image healthBar;
    public float healthAmount = 100;

    private void Start()
    {
        StartCoroutine(addHealth());
    }

    private void Update()
    {
        if(healthAmount <= 0)
        {
            // Application.LoadLevel(Application.loadedLevel);
            Destroy(gameObject);
        }

        
        
    }

    public void TakeDamage(float Damage)
    {
        SoundManagerScript.PlaySound("Hit");
        animator.SetTrigger("Hurt");
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;
    }
   //Reference- https://answers.unity.com/questions/368113/regenerating-health-over-time.html
    IEnumerator addHealth()
    {
        while (true)
        { 
            if (healthAmount < 100)
            { 
                healthAmount += 5;
                healthBar.fillAmount = healthAmount / 100;
                
                yield return new WaitForSeconds(1);
                
            }
            else
            { 
                yield return null;
            }
        }
    }


}
