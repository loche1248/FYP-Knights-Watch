//Reference - https://www.youtube.com/watch?v=AD4JIXQDw0s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossABehaviour : MonoBehaviour
{
	public Transform player;
	public int healthAmount = 500;
	

	public bool isFlipped = false;

	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

	public void TakeDamage(int damage)
	{
		SoundManagerScript.PlaySound("Hit");
		GetComponent<Animator>().SetTrigger("Hurt");
		healthAmount -= damage;
		

		if (healthAmount <= 200)
		{
			GetComponent<Animator>().SetBool("Phase2", true);
		}

		if (healthAmount <= 0)
		{
			Die();
		}
	}

	void Die()
	{

		Destroy(gameObject);
	}
}
