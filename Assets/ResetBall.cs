﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour {

    public Transform spawn;
    public GameObject ball;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("ball"))
        {
            Destroy(other.gameObject);
            Instantiate(ball, spawn.transform.position, spawn.transform.rotation);
        }
    }
}
