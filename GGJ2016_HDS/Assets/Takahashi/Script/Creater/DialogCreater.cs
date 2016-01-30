using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DialogCreater{

   public static void CreateShopDialog(
       Transform parent,MasterShop.Cell data,System.Action oncomplete=null,System.Action onremove=null)
    {
        GameObject g=MonoBehaviour.Instantiate(ResourceManager.Get.GetPrefab("ShopDialog"));

        string text = data.name + "は" + data.gold + "＄かかります。\n" + "購入しますか？";
        g.transform.FindChild("maintext").GetComponent<Text>().text = text;
        if (oncomplete != null)
        {
            g.transform.FindChild("bt_ok").GetComponent<Button>().onClick.AddListener(() => {
                oncomplete();
                UIController.m_dialogController.RemoveDialog(); });
        }
        else
        {
            g.transform.FindChild("bt_ok").GetComponent<Button>().onClick.AddListener(() => {
                UIController.m_dialogController.RemoveDialog();
            });
        }
        g.transform.FindChild("bt_no").GetComponent<Button>().onClick.AddListener(()=>{
            if (onremove != null) onremove();
            UIController.m_dialogController.RemoveDialog();
        });
        g.transform.SetParent(parent, false);
        g.GetComponent<UIController>().InitDialog();
    }
}
