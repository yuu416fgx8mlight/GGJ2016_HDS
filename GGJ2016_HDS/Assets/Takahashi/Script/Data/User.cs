using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class User{
    [SerializeField]
    public List<Character> characters = new List<Character>();
    public int gold;
    public User(List<Character> c,int gold)
    {
        characters = c;
        this.gold = gold;
    }
    public void LoadUser(List<Character> c,int gold)
    {
        characters = c;
        this.gold = gold;
    }
    public void AddGold(int gold)
    {
        this.gold += gold;
    }
}
