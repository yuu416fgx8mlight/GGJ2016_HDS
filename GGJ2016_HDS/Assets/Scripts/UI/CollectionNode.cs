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
		//name = TestMaster.get.master.Characters.list[id].name;
		myImg=Resources.Load<Sprite>("CharaIcon/"+"icon"+id);
		img = transform.FindChild("Image").GetComponent<Image>();
		img.sprite = myImg;
		for (int i = 0; i < GameManager.Get.user.characters.Count; i++) {
			if (GameManager.Get.user.characters[i].id==id) {
				exist = true;
				name = GameManager.Get.user.characters[i].name;
				subscribe = TestMaster.get.master.Characters.list [id].subscripsion;
				gold = TestMaster.get.master.Characters.list [id].gold;
			}
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
