using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class EquipmentNode : MonoBehaviour {
    //とりあえずつかうときに使う
    public MasterShop.param info;
    public EquipmentType type;
    public Transform equipparent;
    public void NodeClick(EquipmentGridType type,EquipmentGrid grid,MasterShop.param data)
    {
        if (type == EquipmentGridType.Category)
        {
            grid.ChangeGrid(EquipmentGridType.Item,this.type);
        }
        if (type == EquipmentGridType.Item)
        {
            int category = data.category;
            DialogCreater.CreateShopDialog(CanvasList.Get.GetCanvas(CanvasType.FrontCanvas).point.transform,
                    data,()=> { SetEquipment((EquipmentType)0); });
        }
    }
    public void SetEquipment(EquipmentType type)
    {
        if (EquipmentType.Hand == type)
        {
            GameObject g=Instantiate(ResourceManager.Get.GetPrefab("Image"))as GameObject;
            g.transform.SetParent(EquipmentPointSystem.Get.HandPoint,false);
        }
    }

}
