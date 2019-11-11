using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
	
	// This script defines the behaviour of our enemies
	
	// Basic enemy parameters
	public int maxHP = 100;
	private int _hitPoints;
	public float knockbackForce = 0.2f;

	public float speed = .2f;
	
	// A reference to our player position
	public Transform playerPos;

	// A reference to the enemy health bar UI asset
	public Slider hpSlider;

	// This is a public property which can be accessed from other scripts.
	// Its job is to GET or SET the _hitpoints variable
	public int HitPoints
	{
		get { return _hitPoints; }
		set
		{
			_hitPoints = value;
			hpSlider.value = _hitPoints;
		}
	}

	// Use this for initialization
	void Start ()
	{
		
		HitPoints = maxHP;
		hpSlider.maxValue = maxHP;
		hpSlider.value = maxHP;

		playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Here we create a new vector pointing to the player and move the enemy toward it
		Vector3 relPos = playerPos.position - transform.position;

		transform.Translate(relPos * speed);
	}

	public void TakeDamage(int damage)
	{

		if (_hitPoints > 0)
		{
			HitPoints -= damage;
		}
		
		else if (_hitPoints <= 0)
		{
			gameObject.SetActive(false);
		}


	}

	public void KnockBack(Vector3 dir)
	{
		transform.Translate(Vector3.Normalize(dir) * knockbackForce);
	}
}
