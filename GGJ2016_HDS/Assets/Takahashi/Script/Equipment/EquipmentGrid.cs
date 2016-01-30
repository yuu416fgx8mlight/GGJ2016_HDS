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
    private Dictionary<EquipmentType, List<MasterShop.param>> m_equpiment = new Dictionary<EquipmentType, List<MasterShop.param>>();
    private EquipmentGridType nowtype;
    private List<GameObject> nowcontent = new List<GameObject>();
    private string[] typeRes =
    {
        "tutuku","Light","Mat","Mat"
    };
    void Start () {
        nowtype = EquipmentGridType.Category;
        m_content = transform.FindChild("Mask/ScrollView/Content").gameObject;
        
        //タイプ項目の作成
        foreach(var i in Enum.GetValues(typeof(EquipmentType)))
        {
            m_equpiment.Add((EquipmentType)i, new List<MasterShop.param>());
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
                g.transform.GetComponent<Image>().sprite = ResourceManager.Get.GetTexture(typeRes[(int)i] + "_0");
                SpriteState state = g.transform.GetComponent<Button>().spriteState;
                state.highlightedSprite = ResourceManager.Get.GetTexture(typeRes[(int)i] + "_1");
                state.pressedSprite = ResourceManager.Get.GetTexture(typeRes[(int)i] + "_1");
                state.disabledSprite = ResourceManager.Get.GetTexture(typeRes[(int)i] + "_0");
                g.transform.GetComponent<Button>().spriteState = state;
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
            returnbutton.transform.GetComponent<Image>().sprite = ResourceManager.Get.GetTexture("back_0");
            SpriteState returnstate = returnbutton.transform.GetComponent<Button>().spriteState;
            returnstate.highlightedSprite = ResourceManager.Get.GetTexture("back_1");
            returnstate.pressedSprite = ResourceManager.Get.GetTexture("back_1");
            returnstate.disabledSprite = ResourceManager.Get.GetTexture("back_0");
            returnbutton.transform.GetComponent<Button>().spriteState = returnstate;
            returnbutton.transform.SetParent(m_content.transform, false);

            nowcontent.Add(returnbutton);
            foreach (var i in m_equpiment[etype])
            {
                MasterShop.param c = i;
                GameObject g = Instantiate(ResourceManager.Get.GetPrefab("EquipmentNode"));
                g.GetComponent<Button>().onClick.AddListener(() => { g.GetComponent<EquipmentNode>().NodeClick(type, this,c); });
                g.GetComponent<EquipmentNode>().type = etype;
                g.transform.GetComponent<Image>().sprite=ResourceManager.Get.GetTexture(i.res + "_0");
                SpriteState state = g.transform.GetComponent<Button>().spriteState;
                state.highlightedSprite= ResourceManager.Get.GetTexture(i.res+"_1");
                state.pressedSprite= ResourceManager.Get.GetTexture(i.res + "_1");
                state.disabledSprite = ResourceManager.Get.GetTexture(i.res + "_0");
                g.transform.GetComponent<Image>().color = c.GetColor();
                g.transform.GetComponent<Button>().spriteState = state;
                g.transform.SetParent(m_content.transform, false);
                nowcontent.Add(g);
            }
        }
    }
}
