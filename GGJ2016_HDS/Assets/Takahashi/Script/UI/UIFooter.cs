using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIFooter : MonoBehaviour {
    private GameObject m_equipmentGrid;
    private Vector2 m_equipmentstartpoisition;
    private const float m_GridObjectSize= 100;
    void Awake()
    {
        m_equipmentGrid = transform.parent.FindChild("EquipmentGrid").gameObject;
        m_equipmentstartpoisition = m_equipmentGrid.transform.localPosition;
    }
    public void OnHome()
    {
		Debug.Log (TestMaster.get.master.Characters.list[1].subscripsion);
		Debug.Log (TestMaster.get.master.Characters.list.Count);
        if(UIController.m_nowController!=null)UIController.m_nowController.Remove();
        GridActive(true);
    }
    public void OnShop()
    {
        //DialogCreater.CreateShopDialog(CanvasList.Get.GetCanvas(CanvasType.UIFrontCanvas).point.transform, "てすとです", () => {
        //    CanvasisTouch(true);
        //    GridActive(true);
        //}, () => {
        //    CanvasisTouch(true);
        //    GridActive(true);
        //});
        GridActive(false);
    }
    public void OnCredit()
    {
        GridActive(false);
    }
    public void OnCollect()
    {
        WindowCreate.CreateCharacterWindow(CanvasList.Get.GetCanvas(CanvasType.UIBackCanvas).point.transform);
        GridActive(false);
    }

    private void GridActive(bool flag)
    {
        float alpha=(flag)?1.0f:0.0f;
        UIAction.Alpha(m_equipmentGrid.GetComponent<CanvasGroup>(), alpha, 0.1f,LeanTweenType.easeOutElastic,()=> { CanvasisTouch(flag); });
    }
    private void CanvasisTouch(bool flag)
    {
        m_equipmentGrid.GetComponent<CanvasGroup>().blocksRaycasts = flag;
        m_equipmentGrid.GetComponent<CanvasGroup>().interactable = flag;

    }

}
