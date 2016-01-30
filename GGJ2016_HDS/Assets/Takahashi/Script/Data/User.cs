using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class User{
    public List<Character> Character = new List<Character>();
    public int gold;
    public User(List<Character> c,int gold)
    {
        Character = c;
        this.gold = gold;
    }
    public void LoadUser(List<Character> c,int gold)
    {
        Character = c;
        this.gold = gold;
    }
}
