using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{

	public float turnSpeed = 5f;

	public float raylen = 5f;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float h = Input.GetAxisRaw("Horizontal");
		
		transform.Rotate(new Vector3(0f, h * turnSpeed, 0f));

		if (Input.GetMouseButton(0))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider != null)
			{
				hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
			}
		}

	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawRay(transform.position, transform.forward * raylen);
	}
}
