using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickRay : MonoBehaviour
{

	public GameObject impactParticles;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			CastRay();
		}
	}

	void CastRay()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.CompareTag("Enemy"))
			{
				//hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
				hit.collider.GetComponent<EnemyScript>().TakeDamage(5);
				Instantiate(impactParticles, hit.point, Quaternion.identity);

			}
		}
	}
}
