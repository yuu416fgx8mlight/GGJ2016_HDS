using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterShop : ScriptableObject {

    public List<param> list = new List<param>();
	
	[System.SerializableAttribute]
	public class param
    {
        public int id;
        public string name;
        public string subscripsion;
        public int gold;
        public int hot;
        public int stress;
        public int category;
    }
}
