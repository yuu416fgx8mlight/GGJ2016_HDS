using UnityEngine;
using System.Collections;

public class EggTouch : MonoBehaviour {
	private Vector2 point;
	private Collider2D collider;
	private GameObject Egg;
	private float Timer=0;
	public GameObject StrockEffect;
	public GameObject PeckEff;
	public GameObject Shock;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		point = Camera.main.ScreenToWorldPoint (Input.mousePosition);


		if (Input.GetMouseButtonDown (0)) {
			collider = Physics2D.OverlapPoint (point);
			if (collider.gameObject.tag == "Player") {
				Instantiate (PeckEff, point, Quaternion.identity);
				collider.GetComponent<EggStatus> ().EggHP--;
			}
		}

		if (Input.GetMouseButton (0)) {
			Timer += Time.deltaTime;
			collider = Physics2D.OverlapPoint (point);
			if (collider.gameObject.tag == "Player"&&Timer>=3) {
				Instantiate (StrockEffect,point, Quaternion.identity);
				collider.gameObject.GetComponent<EggStatus> ().Hot += 1;
				Timer = 0;
			}
		}

		if (Input.GetMouseButtonDown (1)) {
			Timer += Time.deltaTime;
			collider = Physics2D.OverlapPoint (point);
			if (collider.gameObject.tag == "Player") {
				Instantiate (Shock, point, Quaternion.identity);
				collider.gameObject.GetComponent<EggStatus> ().Stres += 1;
				Timer = 0;
			}
		}
	}

}
