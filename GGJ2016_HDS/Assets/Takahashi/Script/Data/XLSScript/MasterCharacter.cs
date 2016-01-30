using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterCharacter : ScriptableObject {

    public List<Cell> list = new List<Cell>();
	
	[System.SerializableAttribute]
	public class Cell
    {
        public int id;
        public string name;
        public string subscripsion;
        public int gold;
        //その他のパラメータ
        public int t_min;
        public int t_max;
        public int hs_min;
        public int hs_max;
    }
}
