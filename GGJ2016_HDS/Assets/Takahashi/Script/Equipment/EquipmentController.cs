using UnityEngine;
using System.Collections;
//要修正クラス
public class EquipmentController : MonoBehaviour {

    private static GameObject m_hand;
    private static GameObject m_ligth;
    public static GameObject GetLight
    {
        get { return m_ligth; }
    }
    private static GameObject m_lag;
    public static GameObject GetLag
    {
        get { return m_lag; }
    }
    private static GameObject m_drag;
    public static GameObject GetDrag
    {
        get { return m_drag; }
    }
    public bool isLight
    {
        get { return m_ligth != null; }
    }
    public bool isHand
    {
        get { return m_hand != null; }
    }
    public bool isLag
    {
        get { return m_lag != null; }
    }
    public bool isDrag
    {
        get { return m_drag != null; }
    }
    public static void SetHand(GameObject obj)
    {
        m_hand = obj;
    }
    public static void RemoveHand()
    {
        if (m_hand == null) return;
        Destroy(m_hand);
    }
    public static void SetLight(GameObject obj)
    {
        m_ligth = obj;
    } 
    public static void RemoveLight()
    {
        if (m_ligth == null) return;
        Destroy(m_ligth);
    }
    public static void SetLag(GameObject obj)
    { 
        m_lag = obj;
    }
    public static void RemoveLag()
    {
        if (m_lag == null) return;
        Destroy(m_lag);
    }
    public static void SetDrag(GameObject obj)
    {
        m_drag = obj;
    }
    public static void RemoveDrag()
    {
        if (m_drag == null) return;
        Destroy(m_drag);
    }
}
