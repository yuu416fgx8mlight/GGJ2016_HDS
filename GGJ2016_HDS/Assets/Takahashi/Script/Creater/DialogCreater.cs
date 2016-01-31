using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DialogCreater{

   public static void CreateShopDialog(
       Transform parent,MasterShop.param data,System.Action oncomplete=null,System.Action onremove=null)
    {
        GameObject g=MonoBehaviour.Instantiate(GameManager.Get.Resource.GetPrefab("ShopDialog"));

        string text = data.name + "は" + data.gold + "＄かかります。\n" + "購入しますか？";
        if (data.category == 0) text = "この卵を" + data.name + "ますか?";
        g.transform.FindChild("maintext").GetComponent<Text>().text = text;

        if (GameManager.Get.user.gold < data.gold)
        {
            g.transform.FindChild("bt_ok").GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            g.transform.FindChild("bt_ok").GetComponent<Button>().interactable = false;
        }

            g.transform.FindChild("bt_ok").GetComponent<Button>().onClick.AddListener(() => {
                if (oncomplete != null) oncomplete();
                GameManager.Get.user.AddGold(-(data.gold));
                UIController.m_dialogController.RemoveDialog();
                CommonFile.push();
            });
           g.transform.FindChild("bt_no").GetComponent<Button>().onClick.AddListener(()=>{
            if (onremove != null) onremove();
            UIController.m_dialogController.RemoveDialog();
            CommonFile.push();
        });
        g.transform.SetParent(parent, false);
        g.GetComponent<UIController>().InitDialog();
    }

	public static void CollectionDialog(Transform parent,int id,string name,string subscription,int gold ,Sprite img){
		int num = id + 1;
		GameObject g=MonoBehaviour.Instantiate(GameManager.Get.Resource.GetPrefab("CollectionDialog"));
		string maintext = "No." + num + " " + name;
		string subtext = subscription+"\n売値: "+gold+"$";
		g.transform.FindChild("maintext").GetComponent<Text>().text = maintext;
		g.transform.FindChild("subtext").GetComponent<Text>().text = subtext;
		g.transform.FindChild("Image").GetComponent<Image>().sprite = img;
		g.transform.SetParent(parent, false);
		g.GetComponent<UIController>().InitDialog();
		g.transform.FindChild("bt_exit").GetComponent<Button>().onClick.AddListener(()=>{
			UIController.m_dialogController.RemoveDialog();
		});
	}
}
