﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonUnlock : MonoBehaviour {
	[SerializeField] Sprite LockedImage;
	[SerializeField] Sprite unlockedImage;
	[SerializeField] Sprite selectedImage;
	[SerializeField] Button[] otherButton;
	[SerializeField] bool locked = true;
	[SerializeField] bool selected = false;
	// Use this for initialization
	void Start () {
		if (locked == true) {
			GetComponent<Button>().interactable=false;
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UnlockItem(){
		this.GetComponent<Image> ().sprite = unlockedImage;
		locked = false;
	}

	public void LockItem(){
		this.GetComponent<Image> ().sprite = LockedImage;
		locked = true;
	}

	public void OnClick(){
		for (int i = 0; i < otherButton.Length; i++) {
			otherButton [i].GetComponent<ButtonUnlock> ().Unselected ();
		}
		this.GetComponent<Image> ().sprite = selectedImage;
	}

	public void Unselected(){
		if (locked == false) {
			this.GetComponent<Image> ().sprite = unlockedImage;
		}
	}

}
