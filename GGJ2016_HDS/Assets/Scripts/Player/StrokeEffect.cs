using UnityEngine;
using System.Collections;

public class StrokeEffect : MonoBehaviour {

	private Vector3 MousePosition;
	private Vector3 ScreenToWorldPointPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//押している間エフェクトがついてくる
		if (Input.GetMouseButton (0)) {
			MousePosition = Input.mousePosition;
			MousePosition.z = 10f;
			ScreenToWorldPointPosition = Camera.main.ScreenToWorldPoint (MousePosition);
			this.transform.position = ScreenToWorldPointPosition;
		} else {
			//なんか止められないのでゴリ押し
			this.transform.position = new Vector3(1000,0,0);
		}
	}
}
