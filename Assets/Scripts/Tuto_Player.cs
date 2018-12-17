﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Player : MonoBehaviour {

	public GameObject objectifPrincipal;
	public GameObject gallery;
	public GameObject map;
	
	void Start () {
		
	}
	
	void Update () {
		if (objectifPrincipal)
		{
			StartCoroutine(TimeToDeathOP());
		}

		if (gallery)
		{
			StartCoroutine(TimeToDeathGA());
		}
	}

	// Condition pour détruire

	IEnumerator TimeToDeathOP()
	{
		yield return new WaitForSeconds (8);
		Destroy(objectifPrincipal);
		map.SetActive(true);
		yield return new WaitForSeconds (8);
		Destroy(map);
	}

	// Tuto Objectif Principal

	IEnumerator TimeToDeathGA()
	{
		yield return new WaitForSeconds (8);
		Destroy(gallery);
	}
}
