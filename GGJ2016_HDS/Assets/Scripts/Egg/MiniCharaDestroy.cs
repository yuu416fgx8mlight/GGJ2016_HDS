﻿using UnityEngine;
using System.Collections;

public class MiniCharaDestroy : MonoBehaviour {
	//AudioManager manager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("GOAL");
	}
	void Destroy(){
		
		Destroy (gameObject);
	}
}
