using UnityEngine;
using System.Collections;

public class ItemPanelController : MonoBehaviour {
	public GameObject syncPanel;
	bool up=false;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick() { 
		if(up==false){
			syncPanel.GetComponent<Animator> ().SetBool ("Up",true);
			up = true;
		}else{syncPanel.GetComponent<Animator> ().SetBool ("Up", false);up = false;}

	}
}
