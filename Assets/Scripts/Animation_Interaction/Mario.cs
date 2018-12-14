﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mario : MonoBehaviour {

    public Animator anim;
    public GameObject fakeARObject;
    public GameObject champignon;
    public AudioClip[] audioMario;
    public AudioMixerGroup[] mixerMario;

    // Use this for initialization
    void Start ()
    {
        ScriptTracker.Instance.FakeARToDeactivate(fakeARObject);
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        anim.SetBool("AnimPlay", true);
    }

    void ActiveChampi()
    {
        champignon.SetActive(true);
    }
}
