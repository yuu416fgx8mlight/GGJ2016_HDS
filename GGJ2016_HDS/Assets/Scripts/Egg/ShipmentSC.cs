﻿using UnityEngine;
using System.Collections;

public class ShipmentSC : MonoBehaviour {
	public Camera _setCamera;
	public GameObject miniChara=null;
	public GameObject InstantPosition=null;

	//Margin
	float margin = 1f; //マージン(画面外に出てどれくらい離れたら消えるか)を指定
	float negativeMargin;
	float positiveMargin;

	void Start ()
	{
		if (_setCamera == null) {
			_setCamera = Camera.main;
		}

		negativeMargin = 0 - margin;
		positiveMargin = 1 + margin;
	}

	// Update is called once per frame
	void Update () 
	{
		transform.position += new Vector3 (0.1f, 0);
		if (this.isOutOfScreen()) {
			if (miniChara != null) 
				Instantiate (miniChara, InstantPosition.transform.position, miniChara.transform.rotation);
			Destroy (gameObject);

		}
	}

	bool isOutOfScreen() 
	{
		Vector3 positionInScreen = _setCamera.WorldToViewportPoint(transform.position);
		positionInScreen.z = transform.position.z;

		if (positionInScreen.x <= negativeMargin ||
			positionInScreen.x >= positiveMargin ||
			positionInScreen.y <= negativeMargin ||
			positionInScreen.y >= positiveMargin)
		{
			return true;
		} else {
			return false;
		}
	}
}