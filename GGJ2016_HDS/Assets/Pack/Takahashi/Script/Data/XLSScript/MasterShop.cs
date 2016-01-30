using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterShop : ScriptableObject {

    public List<Cell> list = new List<Cell>();
	
	[System.SerializableAttribute]
	public class Cell
    {
        public int id;
        public string name;
        public string subscripsion;
        public int gold;
    }
}
