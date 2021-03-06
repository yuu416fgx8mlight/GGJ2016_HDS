﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public ResourceManager Resource;
    public static GameManager Get;

    public Master master;
    public User user;
    public GameObject goldtag;
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
    public void SetGoldTag(GameObject obj)
    {
        goldtag = obj;
        goldtag.GetComponent<Text>().text = user.gold + "$";
    }
    public void AddGold(int add, bool animationflag = true)
    {
        EffectCreater.CreateMoneyEffect3(goldtag.transform);
        StartCoroutine(GoldReal(user.gold, user.gold + add));
        user.AddGold(add);
        SaveDataJsonUtility.Save<User>(user,"savedata");
    }
    IEnumerator GoldReal(int nowgold, int nextgold)
    {
        LeanTween.scale(goldtag, new Vector3(1.2f, 1.2f, 1), 0.3f);
        //大体1秒
        int add = (int)((nextgold - nowgold) / 60);
        add = Mathf.Max(1, add);
        int count = 10;
        if (nextgold - nowgold < 0)
        {
            for (int i = 0; i < 60; ++i)
            {
                count++;
                nowgold += add;
                if (nowgold > user.gold) nowgold = user.gold;
                if (nowgold < user.gold) nowgold = user.gold;
                goldtag.GetComponent<Text>().text = nowgold + "$";
                if (count > 10)
                {
                    count = 0;
                    CommonFile.getmoney();
                }
                yield return null;
            }

            LeanTween.scale(goldtag, new Vector3(1, 1, 1), 0.3f);
            yield break;
        }
    }

}
