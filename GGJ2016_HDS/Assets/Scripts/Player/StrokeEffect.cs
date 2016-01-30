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
			//this.transform.position = new Vector3(1000,0,0);
			StartCoroutine("MoveDestroy");
		}
	}

	public IEnumerator MoveDestroy(){
		yield return new WaitForSeconds (1f);
		Destroy(gameObject);
	}
}
