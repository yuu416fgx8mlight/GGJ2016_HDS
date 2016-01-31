using UnityEngine;
using System.Collections;

public class MiniCharaDestroy : MonoBehaviour {
	//AudioManager manager;
	// Use this for initialization
	private int i;
	public User user;
	public Character chara;
	public int id;
	void Start () {
		user.characters.Add (chara);
	}
	
	// Update is called once per frame
	void Update () {
		i = user.gold;
		Debug.Log (i);
	}

	public void SetEquipment(EquipmentType type,string res,Color c,MasterCharacter.Cell data)
	{
		
	}

	void Destroy(){
		GameManager.Get.AddGold (i);
			Destroy (gameObject);
	}
}
