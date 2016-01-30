using UnityEngine;
using System.Collections;

public class CollectionNode : MonoBehaviour {
	//public MasterCharacter.Cell info;
	public int id;
	[SerializeField] string name;
	[SerializeField] string subscribe;
	[SerializeField] int gold;
	// Use this for initialization
	void Start () {
		//name = TestMaster.get.master.Characters.list[id].name;
		name = GameManager.Get.user.characters[id].name;
		subscribe = TestMaster.get.master.Characters.list [id].subscripsion;
		gold = TestMaster.get.master.Characters.list [id].gold;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AppearDialog(){
		DialogCreater.CollectionDialog (CanvasList.Get.GetCanvas(CanvasType.FrontCanvas).point.transform,id,name, subscribe, gold);
	}

}
