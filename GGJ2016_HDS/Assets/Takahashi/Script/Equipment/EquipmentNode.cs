using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class EquipmentNode : MonoBehaviour {
    //とりあえずつかうときに使う
    public MasterShop.param info;
    public EquipmentType type;
    public void NodeClick(EquipmentGridType type,EquipmentGrid grid,MasterShop.param data)
    {
        if (type == EquipmentGridType.Category)
        {
            grid.ChangeGrid(EquipmentGridType.Item,this.type);
        }
        if (type == EquipmentGridType.Item)
        {
            DialogCreater.CreateShopDialog(CanvasList.Get.GetCanvas(CanvasType.FrontCanvas).point.transform,
                    data);
        }
    }

}
