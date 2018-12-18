﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecraft_Script : MonoBehaviour {

    public Animator steveController;
    public GameObject fakeARObject;
    private int minecraftCount = 0;
    public GameObject dimondsInTheSky;
    public GameObject dimondsInTheSky2;
    public GameObject stick;

    // Use this for initialization
    void Start () {
        steveController = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (minecraftCount >= 3)
        {
            steveController.SetBool("Ending", true);
            dimondsInTheSky.SetActive(false);
            dimondsInTheSky2.SetActive(false);
            stick.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        steveController.SetBool("Hitting", true);
        steveController.SetBool("Idle", false);
    }

    void AddCount ()
    {
        minecraftCount += 1;
        steveController.SetBool("Idle", true);
        steveController.SetBool("Hitting", false);
    }
}
