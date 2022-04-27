using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public int health = 500;

	private Transform player;



	public void DamageTaken(int damage)
	{
		

		health -= damage;

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("Phase2", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		
		Destroy(gameObject);
	}
}
