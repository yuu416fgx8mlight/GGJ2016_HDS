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
        if(user== null)
        {
            user = new User(new List<Character>(), 0);
        }
        SaveDataJsonUtility.Save<User>(user, "savedata");
    }
}
