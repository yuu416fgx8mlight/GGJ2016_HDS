using UnityEngine;
using System.Collections;
public enum EquipmentType
{
    Hand=0,
    Light=1,
    Lag=2,
    Drag=3,
    None
}
public class Equipment:EquipmentController{
    public EquipmentType type = EquipmentType.None;

    public void SetEquipmentType(EquipmentType type)
    {
        this.type = type;
    }
    public void SetController()
    {
        switch (type)
        {
            case EquipmentType.Hand:
                if (isHand) RemoveHand();
                SetHand(gameObject);
                break;
            case EquipmentType.Light:
                if (isLight) RemoveLight();
                SetLight(gameObject);
                break;
            case EquipmentType.Lag:
                if (isLag) RemoveLag();
                SetLag(gameObject);
                break;
            case EquipmentType.Drag:
                if (isDrag) RemoveDrag();
                SetDrag(gameObject);
                break;
        }
    }
    void Start()
    {
        SetController();
    }

}
