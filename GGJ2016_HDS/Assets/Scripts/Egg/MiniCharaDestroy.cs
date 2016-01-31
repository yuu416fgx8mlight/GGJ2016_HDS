using UnityEngine;
using System.Collections;

public class MiniCharaDestroy : MonoBehaviour {
	//AudioManager manager;
	// Use this for initialization
	private int i;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("GOAL");
	}

	public void SetEquipment(EquipmentType type,string res,Color c,MasterCharacter.Cell data)
	{
		i=data.gold;
	}

	void Destroy(){
		GameManager.Get.AddGold (i);
			Destroy (gameObject);
	}
}
