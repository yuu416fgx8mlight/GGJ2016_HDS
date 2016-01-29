using UnityEngine;
using System.Collections;

public class EggAnimation : MonoBehaviour {
	Animator anime;
	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		anime.SetTrigger ("Shake");
		Debug.Log ("hit");
	}
}