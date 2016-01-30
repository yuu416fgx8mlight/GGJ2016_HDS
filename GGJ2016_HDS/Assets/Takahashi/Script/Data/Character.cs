using UnityEngine;
using System.Collections;

//図鑑の情報
public class Character{
    public int id;
    public string name;
    public string subscripsion;
    public int gold;
    public Character(MasterCharacter.Cell master)
    {
        id = master.id;
        name = master.name;
        subscripsion = master.subscripsion;
        gold = master.gold;
    }
    public Character(int id,string name,string subscripsion, int gold)
    {
        this.id = id;
        this.name = name;
        this.subscripsion = subscripsion;
        this.gold = gold;
    }
}
