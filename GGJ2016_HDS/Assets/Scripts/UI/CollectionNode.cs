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
		img = transform.FindChild ("Image").GetComponent<Image> ();
		for (int i = 0; i < GameManager.Get.master.Characters.list.Count; i++) {
			for(int j = 0;j<GameManager.Get.user.characters.Count;j++){
				if (GameManager.Get.user.characters[j].id == id) {
					exist = true;
					int collectID = GameManager.Get.user.characters [j].id;
					myImg = GameManager.Get.Resource.GetCharaIcon ("icon" + collectID);
					//Debug.Log (collectID);//Debug.Log (myImg);
					img = transform.FindChild ("Image").GetComponent<Image> ();
					img.sprite = myImg;
					name = GameManager.Get.master.Characters.list [collectID].name;
					subscribe = GameManager.Get.master.Characters.list [collectID].subscripsion;
					gold = GameManager.Get.master.Characters.list [collectID].gold;
				}
			}
		}
			

		if (exist != true) {
			img.color = new Color(0,0,0,0.7f);
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
