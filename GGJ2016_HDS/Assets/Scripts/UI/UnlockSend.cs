using UnityEngine;
using System.Collections;

public class UnlockSend : MonoBehaviour {
	[SerializeField] GameObject sendButton;
	ButtonUnlock ButtonScr;
	// Use this for initialization
	void Start () {
		ButtonScr = sendButton.GetComponent<ButtonUnlock> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		ButtonScr.UnlockItem ();
	}
}
