using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIFooter : MonoBehaviour {

    public void OnHome()
    {
        if(UIController.m_nowController!=null)UIController.m_nowController.Remove();
    }
    public void OnShop()
    {
        DialogCreater.CreateShopDialog(CanvasList.Get.GetCanvas(CanvasType.UIFrontCanvas).point.transform, "てすとです");
    }
    public void OnCredit()
    {

    }
    public void OnCollect()
    {
        WindowCreate.CreateCharacterWindow(CanvasList.Get.GetCanvas(CanvasType.UIBackCanvas).point.transform);
    }


}
