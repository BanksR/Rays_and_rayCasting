using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
	public int maxHP = 100;
	private int _hitPoints;
	public float knockbackForce = 0.2f;

	public float speed = .2f;
	public Transform playerPos;

	public Slider hpSlider;

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
	}
	
	// Update is called once per frame
	void Update ()
	{
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
