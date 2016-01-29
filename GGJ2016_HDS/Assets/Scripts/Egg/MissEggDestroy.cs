using UnityEngine;
using System.Collections;

public class MissEggDestroy : MonoBehaviour {
	public GameObject Egg;
	public GameObject Ganerate;
	// Use this for initialization
	void Start () {
		Ganerate = GameObject.Find ("GaneratePosition");
		Instantiate (Egg, Ganerate.transform.position,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
		Destroy (gameObject,1);
	}
}
