using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKiller : MonoBehaviour {

	void Awake()
	{
		Destroy(this.gameObject, 2f);
	}
}
