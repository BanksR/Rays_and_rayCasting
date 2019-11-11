using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RayCasting : MonoBehaviour
{

	
	// How fast our player can turn
	public float turnSpeed = 5f;

	
	public float raylen = 5f;
	
	// A game object with particles we can spawn on impact
	public GameObject impactParticles;
	

	
	// Update is called once per frame
	void Update ()
	{
		// Gather player input and store it in variable h
		float h = Input.GetAxisRaw("Horizontal");
		
		// Rotate player around the Y axis
		transform.Rotate(new Vector3(0f, h * turnSpeed, 0f));

		// If the player clicks the left mouse button - run the Shoot() function
		if (Input.GetMouseButtonDown(0))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		// This function is called on every mouse click, it creates a new ray
		// and tests to see what it bumps into.
		
		// Here we declare a new variable of type Ray called ray and initialise
		// it with a start position and direction
		Ray ray = new Ray(transform.position, transform.forward);
		
		// This struct is where all the cool ray cast hit info is kept - very very useful!
		RaycastHit hit;

		
		// If the ray hits something of type 'Enemy' do a bunch of stuff
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.CompareTag("Enemy"))
			{
				// Get a component ref from the enemy hit and do the TakeDamage(), and KnockBack() functions
				hit.collider.GetComponent<EnemyScript>().TakeDamage(5);
				hit.collider.GetComponent<EnemyScript>().KnockBack(hit.point - transform.position);
				
				// A call to our particle spawner function
				Impact(hit.point);
				
			}
		}

	}

	private void OnDrawGizmos()
	{
		// Debug info for the ray - so we can see it in the scene view
		Gizmos.DrawRay(transform.position, transform.forward * raylen);
	}

	void Impact(Vector3 pos)
	{
		// This function is responsible for spawning our impact particles
		// it is passed a position as a parameter - this is the point in world space
		// where the ray hit.
		
		Instantiate(impactParticles, pos, Quaternion.identity);
	}
}
