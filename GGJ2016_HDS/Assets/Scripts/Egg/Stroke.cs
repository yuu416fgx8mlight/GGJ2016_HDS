using UnityEngine;
using System.Collections;

public class Stroke : MonoBehaviour {

	public GameObject StrokeHeart;

	private Vector3 MousePosition;
	private Vector3 ScreenToWorldPointPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MousePosition = Input.mousePosition;
		MousePosition.z = 10f;

		ScreenToWorldPointPosition = Camera.main.ScreenToWorldPoint (MousePosition);
		gameObject.transform.position = ScreenToWorldPointPosition;
		/*if (Input.GetMouseButton (0)) {
			Vector3 MousePosition;
c
			MousePosition.z = 10f;
			Instantiate (StrokeHeart, MousePosition,Quaternion.identity);
		}*/
	}
}
