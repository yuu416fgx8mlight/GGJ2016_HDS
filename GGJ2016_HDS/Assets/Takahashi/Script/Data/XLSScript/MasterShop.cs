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
        public string res;
        public string color;
        public int gread;

        public Color GetColor()
        {
            switch (color)
            {
                case "white":
                    return Color.white;
                case "blue":
                    return Color.blue;
                case "red":
                    return Color.red;
                case "yellow":
                    return Color.yellow;
            }
            return Color.white;
        }
    }
}
