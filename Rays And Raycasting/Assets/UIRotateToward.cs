using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRotateToward : MonoBehaviour
{
	private RectTransform rect;

	// Use this for initialization
	void Start ()
	{
		rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 relPos = Camera.main.transform.position - transform.position;
		
		Quaternion rot = Quaternion.LookRotation(relPos, Vector3.up);

		rect.rotation = rot;
	}
}
