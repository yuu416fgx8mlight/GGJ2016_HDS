using UnityEngine;
using System.Collections;

public class EggTouch : MonoBehaviour {
	private Vector2 point;
	private Collider2D collider;
	private GameObject Egg;
	private float Timer=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		point = Camera.main.ScreenToWorldPoint (Input.mousePosition);


		if (Input.GetMouseButtonDown (0)) {
			collider = Physics2D.OverlapPoint (point);
			if (collider.gameObject.tag == "Player") {
				collider.GetComponent<EggStatus> ().EggHP--;
			}
		}
		Timer += Time.deltaTime;
		if (Input.GetMouseButton (0)) {
			collider = Physics2D.OverlapPoint (point);
			if (collider.gameObject.tag == "Player"&&Timer>=1) {
				collider.gameObject.GetComponent<EggStatus> ().Hot += 1;
				Timer = 0;
			}
		}

		if (Input.GetMouseButtonDown (1)) {
			collider = Physics2D.OverlapPoint (point);
			if (collider.gameObject.tag == "Player") {
				collider.gameObject.GetComponent<EggStatus> ().Stres += 1;
				Timer = 0;
			}
		}
	}

}
