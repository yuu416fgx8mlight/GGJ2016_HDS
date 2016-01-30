using UnityEngine;
using System.Collections;

public class TestMaster : MonoBehaviour {
    private Master master;
    private User user;
	// Use this for initialization
	void Start () {
        master = new Master();
        user = SaveDataJsonUtility.Load<User>("savedata");
        master.LoadData();
        foreach(var i in master.Characters.list)
        {
            Debug.Log(i.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
