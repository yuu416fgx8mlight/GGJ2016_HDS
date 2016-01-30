using UnityEngine;
using System.Collections;

public class ShipmentSC : MonoBehaviour {
	public Camera _setCamera;
	public GameObject miniChara;
	public GameObject InstantPosition;
	private GameObject Ganerate;
	public GameObject Egg;
	public GameObject ShipSmoke;
	//Margin
	float margin = 1f; //マージン(画面外に出てどれくらい離れたら消えるか)を指定
	float negativeMargin;
	float positiveMargin;

	void Start ()
	{
		_setCamera = GetComponent<Camera> ();
		InstantPosition = GameObject.Find ("House");
		Ganerate = GameObject.Find ("GaneratePosition");
		if (_setCamera == null) {
			_setCamera = Camera.main;
		}
		/*ShipSmoke = (GameObject)Resources.Load ("Effect/Shipment");
		Instantiate (ShipSmoke, gameObject.transform.position, Quaternion.identity);
		ShipSmoke.transform.parent = transform;*/
		negativeMargin = 0 - margin;
		positiveMargin = 1 + margin;
	}

	// Update is called once per frame
	void Update () 
	{
	//	transform.position += new Vector3 (0.1f, 0);
		if (this.isOutOfScreen()) {
			if (miniChara != null) 
				Instantiate (miniChara, InstantPosition.transform.position, miniChara.transform.rotation);
			Instantiate (Egg, Ganerate.transform.position,Quaternion.identity);
			Destroy (gameObject);

		}
	}

	bool isOutOfScreen() 
	{
		Vector3 positionInScreen = _setCamera.WorldToViewportPoint(transform.position);
		positionInScreen.z = transform.position.z;

		if (positionInScreen.x <= negativeMargin ||
			positionInScreen.x >= positiveMargin ||
			positionInScreen.y <= negativeMargin ||
			positionInScreen.y >= positiveMargin)
		{
			return true;
		} else {
			return false;
		}
	}
}
