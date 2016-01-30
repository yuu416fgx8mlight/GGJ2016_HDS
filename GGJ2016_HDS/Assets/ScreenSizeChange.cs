using UnityEngine;
using System.Collections;

public class ScreenSizeChange : MonoBehaviour {
	public int ScreenWidth;
	public int ScreenHeight;
	// Use this for initialization

	void Awake(){
		if (Application.platform == RuntimePlatform.WindowsPlayer ||
		   Application.platform == RuntimePlatform.OSXPlayer ||
		   Application.platform == RuntimePlatform.LinuxPlayer) {
			Screen.SetResolution (ScreenWidth, ScreenHeight, false);
		}
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
