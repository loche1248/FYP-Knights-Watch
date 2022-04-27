using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightHealth : MonoBehaviour
{
    public Animator animator;
    public Image healthBar;
    public float healthAmount = 100;

    private void Update()
    {
        if(healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        
        
    }

    public void TakeDamage(float Damage)
    {
        animator.SetTrigger("Hurt");
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;
    }

    

}
