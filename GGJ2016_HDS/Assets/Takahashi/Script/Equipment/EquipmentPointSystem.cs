using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipmentPointSystem : MonoBehaviour {
    public static EquipmentPointSystem Get;
    public Transform HandPoint;
    public Transform LagPiont;
    public Transform LightPoint;
    void Awake()
    {
        Get = this;
        foreach(Transform i in transform)
        {
            if (i.name == "HandPoint") HandPoint = i;
            if (i.name == "LagPoint") LagPiont = i;
            if (i.name == "LightPoint")LightPoint = i;
        }

    }

}
