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
        animator.SetTrigger("Hurt");
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;
    }

    IEnumerator addHealth()
    {
        while (true)
        { // loops forever...
            if (healthAmount < 100)
            { // if health < 100...
                healthAmount += 5;
                
                // increase health and wait the specified time
                yield return new WaitForSeconds(1);
                
            }
            else
            { // if health >= 100, just yield 
                yield return null;
            }
        }
    }


}
