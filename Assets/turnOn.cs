﻿using UnityEngine;
using System.Collections;


public class turnOn : MonoBehaviour {
public GameObject lightParent;
private AudioSource audio;
private AudioSource engine;
private Animation leverAnim;
private bool isLight;
	// Use this for initialization
	void Start () {
	audio = GameObject.FindWithTag("leverSound").GetComponent<AudioSource>();
	engine = GameObject.FindWithTag("engine").GetComponent<AudioSource>();
	leverAnim = GameObject.FindWithTag("leverCube").GetComponent<Animation>();
	isLight = false;
	}

	IEnumerator MyMethod() {
		yield return new WaitForSeconds(5.5f);

		if (!isLight) {
		
			isLight = true;
			var parentLight = GameObject.FindWithTag("allLights");
			parentLight.GetComponent<RotateLight>().enabled = true;
			
			var lights = lightParent.GetComponentsInChildren<Light>(true);
			
			foreach (Light light in lights)
			{
				light.enabled = true;
			}
			engine.Play();
			
			
		} else {

			isLight = false;
			var parentLight = GameObject.FindWithTag("allLights");
			parentLight.GetComponent<RotateLight>().enabled = false;
			
			var lights = lightParent.GetComponentsInChildren<Light>(true);
			
			foreach (Light light in lights)
			{
				light.enabled = false;
			}
			engine.Stop();	
		}

	}

	// Update is called once per frame
	void Update () {
		//Respond to init
		if(Input.GetButtonDown("Test")){
			audio.Play();
//			GetComponent<Animation>().Play();
			if (!isLight) {
				leverAnim["cubeRotate"].speed = 1;
				leverAnim["cubeRotate"].time = 0;
				leverAnim.Play ();
			} else {
				leverAnim["cubeRotate"].speed = -1;
				leverAnim["cubeRotate"].time = leverAnim["cubeRotate"].length;
				leverAnim.Play ();
			}
			StartCoroutine("MyMethod");

					}
	}
}

