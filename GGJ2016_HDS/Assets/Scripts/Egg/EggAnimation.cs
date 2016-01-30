using UnityEngine;
using System.Collections;

public class EggAnimation : MonoBehaviour {
	Animator anime;
	public GameObject smoke;
	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Smoke(){
		Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
	}

	void OnCollisionEnter2D(Collision2D col){
		anime.SetTrigger ("Shake");
		Debug.Log ("hit");
	}
}