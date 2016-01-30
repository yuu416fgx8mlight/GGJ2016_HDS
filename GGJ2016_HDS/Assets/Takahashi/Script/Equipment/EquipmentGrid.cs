using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
public enum EquipmentGridType
{
    Category,
    Item
}
public class EquipmentGrid : MonoBehaviour {
    private GameObject m_content;
    private Dictionary<EquipmentType, List<MasterShop.Cell>> m_equpiment = new Dictionary<EquipmentType, List<MasterShop.Cell>>();
    private EquipmentGridType nowtype;
    private List<GameObject> nowcontent = new List<GameObject>();
    void Start () {
        nowtype = EquipmentGridType.Category;
        m_content = transform.FindChild("Mask/ScrollView/Content").gameObject;
        
        //タイプ項目の作成
        foreach(var i in Enum.GetValues(typeof(EquipmentType)))
        {
            m_equpiment.Add((EquipmentType)i, new List<MasterShop.Cell>());
        }
        foreach(var i in TestMaster.get.master.Shop.list)
        {
            m_equpiment[(EquipmentType)i.category].Add(i);
        }
        ChangeGrid(nowtype, EquipmentType.None);


    }
    public void ChangeGrid(EquipmentGridType type,EquipmentType etype)
    {
        foreach(var i in nowcontent)
        {
            Destroy(i);
        }
        nowcontent.Clear();
        if (type == EquipmentGridType.Category)
        {
            //タイプ項目の作成
            foreach (var i in Enum.GetValues(typeof(EquipmentType)))
            {
                if ((EquipmentType)i == EquipmentType.None) return;
                GameObject g = Instantiate(ResourceManager.Get.GetPrefab("EquipmentNode"));
                g.GetComponent<Button>().onClick.AddListener(() => { g.GetComponent<EquipmentNode>().NodeClick(type, this,null); });
                g.GetComponent<EquipmentNode>().type = (EquipmentType)i;
                g.transform.SetParent(m_content.transform, false);
                nowcontent.Add(g);
            }

        }
        if (type == EquipmentGridType.Item)
        {
            GameObject returnbutton = Instantiate(ResourceManager.Get.GetPrefab("ReturnNode"));
            returnbutton.GetComponent<Button>().onClick.AddListener(() => {
                ChangeGrid(EquipmentGridType.Category, EquipmentType.None);
                nowtype = EquipmentGridType.Category;
            });
            returnbutton.transform.SetParent(m_content.transform, false);

            nowcontent.Add(returnbutton);
            foreach (var i in m_equpiment[etype])
            {
                MasterShop.Cell c = i;
                GameObject g = Instantiate(ResourceManager.Get.GetPrefab("EquipmentNode"));
                g.GetComponent<Button>().onClick.AddListener(() => { g.GetComponent<EquipmentNode>().NodeClick(type, this,c); });
                g.GetComponent<EquipmentNode>().type = etype;
                g.transform.SetParent(m_content.transform, false);
                nowcontent.Add(g);
            }
        }
    }
}
