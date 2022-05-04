//Reference - https://www.youtube.com/watch?v=AD4JIXQDw0s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBBehaviour : MonoBehaviour
{
	public Transform player;
	public int healthAmount = 500;
	public ParticleSystem deathParticle;

	public bool isFlipped = false;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;

	}

	void Update()
	{
		if (player == null)
		{
			Destroy(gameObject);
		}
	}

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;
		//Reference - https://answers.unity.com/questions/131158/how-can-i-check-if-an-object-is-null.html
		if (player != null)
		{
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




	}

	public void TakeDamage(int damage)
	{
		SoundManagerScript.PlaySound("Hit");
		GetComponent<Animator>().SetTrigger("Hurt");
		healthAmount -= damage;


		if (healthAmount <= 250)
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
		//Reference for death particle - https://www.youtube.com/watch?v=nT031tVrGC0&t=362s

		Instantiate(deathParticle, transform.position, Quaternion.identity);
		Destroy(gameObject);
		SceneManager.LoadScene("VictoryScene");
	}
}
