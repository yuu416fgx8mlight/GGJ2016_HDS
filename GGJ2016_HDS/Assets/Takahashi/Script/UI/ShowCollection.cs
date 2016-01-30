using UnityEngine;
using System.Collections;

public class ShowCollection : MonoBehaviour {
	[SerializeField] GameObject node;
	// Use this for initialization
	void Start () {
		for(int i=0;i<TestMaster.get.master.Characters.list.Count;i++){
		GameObject obj = (GameObject)Instantiate(node);
		GameObject parent = gameObject.transform.FindChild("ScrollView/Content").gameObject;
			obj.GetComponent<CollectionNode>().id = i;
			obj.transform.SetParent (parent.transform,false); 
		//obj.transform.parent = GameObject.Find("CharacterWindow/ScrollView/Content").gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateCollection(){
		for(int i=0;i<TestMaster.get.master.Characters.list.Count;i++){
		GameObject obj = (GameObject)Instantiate(node, transform.position, Quaternion.identity);
		obj.transform.SetParent(GameObject.Find("CharacterWindow/ScrollView/Content").gameObject.transform.parent);
		//obj.transform.parent = GameObject.Find("CharacterWindow/ScrollView/Content").gameObject.transform;
		}
	}
}
