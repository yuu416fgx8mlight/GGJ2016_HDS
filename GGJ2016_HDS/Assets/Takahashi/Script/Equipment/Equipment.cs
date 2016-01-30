using UnityEngine;
using System.Collections;
public enum EquipmentType
{
    Hand=0,
    Light=1,
    Lag=2,
    None
}
public class Equipment{
    public EquipmentType type;
    public string name;
    public string subscripsion;
    public int heat;
    public int stress;

    public Equipment(EquipmentType type,string name,string subscription,int heat,int stress)
    {
        this.type = type;
        this.name = name;
        this.subscripsion = subscripsion;
        this.heat = heat;
        this.stress = stress;
    }
    public Equipment(MasterShop.Cell masterdata)
    {
        //マスターデータから取得
    }
}
