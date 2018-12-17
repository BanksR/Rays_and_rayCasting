using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
	public int maxHP = 100;
	private int _hitPoints;

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
		
	}

	public void TakeDamage(int damage)
	{

		if (_hitPoints > 0)
		{
			HitPoints -= damage;
		}

		
	}
}
