using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIFooter : MonoBehaviour {
    private GameObject m_equipmentGrid;
    private GameObject m_goldtag;
    void Awake()
    {
        m_equipmentGrid = transform.parent.FindChild("EquipmentGrid").gameObject;
        m_goldtag = transform.parent.FindChild("GoldTag").gameObject;
    }
    public void OnHome()
    {
        if(UIController.m_nowController!=null)UIController.m_nowController.Remove();
        GridActive(true);
        CommonFile.push();
    }
    public void OnShop()
    {
        GridActive(false);
        CommonFile.push();
    }
    public void OnCredit()
    {
		WindowCreate.CreateCredit (CanvasList.Get.GetCanvas (CanvasType.UIBackCanvas).point.transform);
        GridActive(false);
        CommonFile.push();
    }
    public void OnCollect()
    {
        WindowCreate.CreateCharacterWindow(CanvasList.Get.GetCanvas(CanvasType.UIBackCanvas).point.transform);
        GridActive(false);
        CommonFile.push();
    }
    public void OnHelp()
    {
        WindowCreate.CreateHelp(CanvasList.Get.GetCanvas(CanvasType.UIBackCanvas).point.transform);
        GridActive(false);
        CommonFile.push();
    }

    private void GridActive(bool flag)
    {
        float alpha=(flag)?1.0f:0.0f;
        UIAction.Alpha(m_equipmentGrid.GetComponent<CanvasGroup>(), alpha, 0.25f,LeanTweenType.easeOutElastic,()=> { CanvasisTouch(flag); });

        UIAction.Alpha(m_goldtag.GetComponent<CanvasGroup>(), alpha, 0.25f, LeanTweenType.easeOutElastic, () => { CanvasisTouch(flag); });

    }
    private void CanvasisTouch(bool flag)
    {
        m_equipmentGrid.GetComponent<CanvasGroup>().blocksRaycasts = flag;
        m_equipmentGrid.GetComponent<CanvasGroup>().interactable = flag;
        m_goldtag.GetComponent<CanvasGroup>().blocksRaycasts = flag;
        m_goldtag.GetComponent<CanvasGroup>().interactable = flag;
    }

}
