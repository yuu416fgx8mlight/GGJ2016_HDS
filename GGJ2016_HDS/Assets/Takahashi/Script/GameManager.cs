using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {
    public ResourceManager Resource;
    public static GameManager Get;

    public Master master;
    public User user;
    void Awake()
    {
        Get = this;
        master = new Master();
        Resource = transform.FindChild("ResourceManager").GetComponent<ResourceManager>();
        Resource.Initialize();
        
        user = SaveDataJsonUtility.Load<User>("savedata");
        master.LoadData();
        //Debug.Log(user.Character[0].name);
        if(user== null)
        {
			user = new User(new List<Character>(), 0);
        }
		//Debug.Log (user.characters [1].name);
		//user.characters.Add (new Character(1,"hoge","hoheoh",100));
		//Debug.Log(Application.persistentDataPath); 
        SaveDataJsonUtility.Save<User>(user, "savedata");

    }
}
