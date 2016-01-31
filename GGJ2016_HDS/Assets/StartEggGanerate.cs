using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StartEggGanerate : MonoBehaviour {
	private GameObject egg;

	// Use this for initialization
	void Start () {
		egg=(GameObject)Resources.Load ("Character/Egg");
		Instantiate (egg,gameObject.transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
