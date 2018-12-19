using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickRay : MonoBehaviour
{
	// This script generates a raycast based on mouseposition / click
	// This is a fundamental piece of code to underestand
	
	// Impact particles
	public GameObject impactParticles;
	
	
	
	// Update is called once per frame
	void Update ()
	{
		// If our player clicks the left mouse button - run our CastRay() function...
		if (Input.GetMouseButtonDown(0))
		{
			CastRay();
		}
	}

	
	void CastRay()
	{
		// Here we declare a new variable of type Ray called ray - and initialise it using a function of the Camera class
		// that generates a ray based on a screen position - in our case - the mouse position when the function was called
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// A new Raycast hit object - here we find all the useful hit info / data
		RaycastHit hit;
		
		
		// Testing our raycast hit - what did it hit?
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.CompareTag("Enemy"))
			{
				
				// If we hit an enemy, we know we can grab it's EnemyScript class and do stuff to it
				hit.collider.GetComponent<EnemyScript>().TakeDamage(5);
				Instantiate(impactParticles, hit.point, Quaternion.identity);

			}
		}
	}
}
