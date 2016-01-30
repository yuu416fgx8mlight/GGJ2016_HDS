using UnityEngine;
using System.Collections;
using System;
//コントローラを使うものはシーン上に一つしかない
public class UIController : MonoBehaviour {
    //now
    private static ControllFunc m_onendaction;
    private static ControllFunc m_onstartaction;
    private static GameObject m_nowObject;
    private CanvasGroup m_canvasGroup;
    public static UIController m_nowController;
    //Dialog
    private static ControllFunc m_ondialogendaction;
    private static ControllFunc m_ondialogstartaction;
    private static GameObject m_nowDialogObject;
    private CanvasGroup m_DialogCanvasGroup;
    public static UIController m_dialogController;
    //backscreen
    private static CanvasGroup m_bgCanvasGroup;
    private static Stack m_BGStack = new Stack();

   
    public void Init()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();
        if (m_nowController != null)
        {
            m_onendaction(onendcomplete);
        }
        else
        {
            m_nowObject = gameObject;
            m_nowController = this;
            SetStartAction(StartAction);
            SetEndAction(EndAction);
            m_onstartaction(onstartcomplete);
        }
        SetBG(m_nowObject.transform.parent);
    }
    public void Remove()
    {
        m_onendaction(removecomplete);
    }
    private void removecomplete()
    {
        m_nowController = null;
        Destroy(m_nowObject);
        SetStartAction(StartAction);
        SetEndAction(EndAction);
        m_nowObject = gameObject;
        m_nowController = this;
        m_onstartaction(onstartcomplete);
        ResetBG();
    }
    protected void SetStartAction(ControllFunc func)
    {
        m_onstartaction = func;
    }
    protected void SetEndAction(ControllFunc func)
    {
        m_onendaction = func;
    }
    private void StartAction(Action func)
    {
        transform.localPosition = new Vector2(CommonFile.ScreenWidth, 0);
        UIAction.MoveActionX(m_canvasGroup, 0, 1, 0.1f, 0.1f, LeanTweenType.linear, () => { func(); });
    }
    private void EndAction(Action func)
    {
        UIAction.MoveActionX(m_canvasGroup, -CommonFile.ScreenWidth, 0, 0.1f, 0.1f, LeanTweenType.linear, () => { func(); });
    }
    private void onstartcomplete()
    {
        SetStartAction(StartAction);
        SetEndAction(EndAction);
    }
    private void onendcomplete()
    {
        m_nowController = null;
        if(m_nowObject)Destroy(m_nowObject);
        SetStartAction(StartAction);
        SetEndAction(EndAction);
        m_nowObject = gameObject;
        m_nowController = this;
        m_onstartaction(onstartcomplete);
        CloseBG();
    }
    //Dialog
    public void InitDialog()
    {
        m_DialogCanvasGroup = GetComponent<CanvasGroup>();
        if (m_dialogController != null)
        {
            m_ondialogendaction(ondialogendcomplete);
        }
        else
        {
            m_nowDialogObject = gameObject;
            m_dialogController = this;
            SetDialogStartAction(DialogStartAction);
            SetDialogEndAction(DialogEndAction);
            m_ondialogstartaction(ondialogstartcomplete);
        }
        SetBG(m_nowDialogObject.transform.parent);

    }
    public void RemoveDialog()
    {
        m_ondialogendaction(ondialogendcomplete);
    }
    protected void SetDialogStartAction(ControllFunc func)
    {
        m_ondialogstartaction = func;
    }
    protected void SetDialogEndAction(ControllFunc func)
    {
        m_ondialogendaction = func;
    }
    private void DialogStartAction(Action func)
    {
        transform.localPosition= new Vector2(0,0);
        transform.localScale = new Vector3(1, 0, 1);
        transform.GetComponent<CanvasGroup>().alpha = 0;
        UIAction.ScaleActionY(m_DialogCanvasGroup, 1, 1, 0.1f, 0.1f, LeanTweenType.linear, () => { func(); });
    }
    private void DialogEndAction(Action func)
    {
        UIAction.ScaleActionY(m_DialogCanvasGroup, 0, 0, 0.1f, 0.1f, LeanTweenType.linear, () => { func(); });
    }
    private void ondialogstartcomplete()
    {
        SetDialogStartAction(DialogStartAction);
        SetDialogEndAction(DialogEndAction);
    }
    private void ondialogendcomplete()
    {
        m_dialogController = null;
        Destroy(m_nowDialogObject);
        SetDialogStartAction(DialogStartAction);
        SetDialogEndAction(DialogEndAction);
        m_nowDialogObject = gameObject;
        m_dialogController = this;
        m_ondialogstartaction(ondialogstartcomplete);
        CloseBG();
    }


    private void SetBG(Transform parent)
    {
        if (m_bgCanvasGroup == null) m_bgCanvasGroup = GameObject.FindGameObjectWithTag("BackGround").GetComponent<CanvasGroup>();
        m_bgCanvasGroup.alpha = 1;
        m_bgCanvasGroup.blocksRaycasts = true;
        m_bgCanvasGroup.interactable = true;
        
        m_bgCanvasGroup.transform.SetParent(parent);
        m_bgCanvasGroup.transform.SetAsFirstSibling();
        m_BGStack.Push(transform.parent);
        Debug.Log(m_BGStack.Count);
    }
    public void CloseBG()
    {
        if (m_bgCanvasGroup == null) return;
        Debug.Log(m_BGStack.Count);
        if (m_BGStack.Count <= 0)return;
        m_BGStack.Pop();
        if (m_BGStack.Count <= 0)
        {
            m_bgCanvasGroup.interactable = false;
            m_bgCanvasGroup.alpha = 0;
            m_bgCanvasGroup.blocksRaycasts = false;
            return;
        }
        m_bgCanvasGroup.transform.SetParent(m_BGStack.Peek()as Transform);
        m_bgCanvasGroup.transform.SetAsFirstSibling();

    }
    public void ResetBG()
    {
        m_BGStack.Clear();
        m_bgCanvasGroup.interactable = false;
        m_bgCanvasGroup.alpha = 0;
        m_bgCanvasGroup.blocksRaycasts = false;
    }
    public static bool isUseController()
    {
        return m_nowObject != null | m_nowDialogObject != null;
    }
    
}
