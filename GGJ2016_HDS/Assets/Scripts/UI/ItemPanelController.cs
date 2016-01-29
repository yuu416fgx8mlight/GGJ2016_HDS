using UnityEngine;
using System.Collections;

public class ItemPanelController : MonoBehaviour {
	[SerializeField] GameObject syncPanel;
	[SerializeField] GameObject[] otherPanel;
	[SerializeField] GameObject[] otherButton;
	ItemPanelController[] otherScr = new ItemPanelController[3];
	int panelNum=3;
	Animator syncAnimator;
	Animator[] otherAnimator = new Animator[3];
	public bool up=false;
	// Use this for initialization
	void Start () {
		syncAnimator = syncPanel.GetComponent<Animator> ();
		for (int i = 0; i < panelNum; i++) {
			otherAnimator[i] = otherPanel[i].GetComponent<Animator> ();
			otherScr[i] = otherButton[i].GetComponent<ItemPanelController> ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick() { 
		for (int i = 0; i < otherPanel.Length; i++) {
			otherAnimator[i].SetBool ("Up",false);
			otherScr [i].up = false;
		}
		if(up==false){
			syncAnimator.SetBool ("Up",true);
			up = true;
		}else{syncAnimator.SetBool ("Up", false);up = false;}

	}
}
