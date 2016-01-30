using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	public GameObject TouchEffect;

	private Vector3 TouchPosition;
	private Vector3 TouchWorldPointPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			TouchPosition = Input.mousePosition;
			TouchPosition.z = 10f;
			TouchWorldPointPosition = Camera.main.ScreenToWorldPoint (TouchPosition);
			Instantiate (TouchEffect, TouchWorldPointPosition, Quaternion.identity);
		}
	}
}
