using UnityEngine;
using System.Collections;

public class testManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) { 
			Sound.Instance.PlayBGM (0);
		}
	
	}
}
