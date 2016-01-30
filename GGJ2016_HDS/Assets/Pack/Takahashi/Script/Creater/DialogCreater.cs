using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DialogCreater{

   public static void CreateShopDialog(Transform parent,string maintext,System.Action oncomplete=null)
    {
        GameObject g=MonoBehaviour.Instantiate(ResourceManager.Get.GetPrefab("ShopDialog"));
        g.transform.FindChild("maintext").GetComponent<Text>().text = maintext;
        if (oncomplete != null) g.transform.FindChild("bt_ok").GetComponent<Button>().onClick.AddListener(() => { oncomplete(); });
        g.transform.FindChild("bt_no").GetComponent<Button>().onClick.AddListener(()=>{ UIController.m_dialogController.RemoveDialog(); });
        g.transform.SetParent(parent, false);
        g.GetComponent<UIController>().InitDialog();
    }
}
