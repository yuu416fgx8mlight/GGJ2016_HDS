using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Master{
    private MasterCharacter m_characters;
    public MasterCharacter Characters
    {
        get { return m_characters; }
    }
    private MasterShop m_shop;
    public MasterShop Shop
    {
        get { return m_shop; }
    }

    public void LoadData()
    {
        m_characters = Resources.Load<MasterCharacter>("MasterData/Data/MasterCharacter.xls");
        m_shop = Resources.Load<MasterShop>("MasterData/Data/MasterShop.xls");
    }
}
