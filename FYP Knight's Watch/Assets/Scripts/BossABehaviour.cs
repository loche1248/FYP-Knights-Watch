using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossABehaviour : MonoBehaviour
{
	public Transform player;
	public int health = 500;

	public bool isFlipped = false;

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
