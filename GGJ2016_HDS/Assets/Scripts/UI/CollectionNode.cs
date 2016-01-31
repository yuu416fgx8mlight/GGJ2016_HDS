using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CollectionNode : MonoBehaviour {
	//public MasterCharacter.Cell info;
	public int id;
	[SerializeField] string name;
	[SerializeField] string subscribe;
	[SerializeField] int gold;
	[SerializeField] bool exist=false;
	[SerializeField] Image img;
	[SerializeField] Sprite myImg;
	// Use this for initialization
	void Start () {
		if (id < GameManager.Get.user.characters.Count) {
			exist = true;
			int collectID = GameManager.Get.user.characters [id].id;
			myImg = GameManager.Get.Resource.GetCharaIcon ("icon" + collectID);
			Debug.Log (collectID);
			Debug.Log (myImg);
			img = transform.FindChild ("Image").GetComponent<Image> ();
			img.sprite = myImg;
			name = GameManager.Get.user.characters[id].name;
			subscribe = GameManager.Get.user.characters[id].name;
			gold = GameManager.Get.user.characters[id].gold;
			/*
		for (int i = 0; i < GameManager.Get.user.characters.Count; i++) {
			if (GameManager.Get.user.characters[i].id==id) {
				exist = true;
				name = GameManager.Get.user.characters[i].name;
				subscribe = GameManager.Get.user.characters[i].name;
				gold = GameManager.Get.user.characters[i].gold;
				//subscribe = TestMaster.get.master.Characters.list [id].subscripsion;
				//gold = TestMaster.get.master.Characters.list [id].gold;
			}
		}
		*/
		}
		if (exist != true) {
			img.color = new Color(0.1f,0.1f,0.1f);
			GetComponent<Button> ().interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AppearDialog(){
		DialogCreater.CollectionDialog (CanvasList.Get.GetCanvas(CanvasType.FrontCanvas).point.transform,id,name, subscribe, gold,myImg);
	}

}
