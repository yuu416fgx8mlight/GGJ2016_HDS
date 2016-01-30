using UnityEngine;
using System.Collections;

public class TestMaster : MonoBehaviour {
    public Master master;
    public User user;
    public static TestMaster get;

	// Use this for initialization
	void Awake () {
        get = this;
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
