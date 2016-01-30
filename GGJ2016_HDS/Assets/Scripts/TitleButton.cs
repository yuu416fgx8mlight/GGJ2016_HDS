using UnityEngine;
using System.Collections;

public class TitleButton : MonoBehaviour {

	//2重呼び出し防止用フラグ
	private bool SceneFrag;

	// Use this for initialization
	void Start () {
		SceneFrag = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnStartClick() {
		if (!SceneFrag) {
			SceneFrag = true;
			FadeManager.Instance.LoadLevel ("Main", 1.0f);
		}
	}

	public void OnCreditClick(){
		if (!SceneFrag) {
			SceneFrag = true;
			FadeManager.Instance.LoadLevel ("Credit", 1.0f);
		}
	}
}
