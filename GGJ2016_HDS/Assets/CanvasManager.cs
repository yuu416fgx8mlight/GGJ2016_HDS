using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {
	static public CanvasList instance;
	static public CharacterStatus status;
	static public StartEggGanerate egg;

	// Use this for initialization
	void Awake(){
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}

		if (egg == null&&status==null) {
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
}
