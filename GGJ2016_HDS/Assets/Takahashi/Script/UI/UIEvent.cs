using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UIEvent :MonoBehaviour,
IDeselectHandler,//ここからインターフェイス設定.
IDragHandler,
IDropHandler,
IMoveHandler,
IPointerClickHandler,
IPointerDownHandler,
IPointerEnterHandler,
IPointerExitHandler,
IPointerUpHandler,
IScrollHandler,
IUpdateSelectedHandler//ここまでインターフェイス設定.
{
    public virtual void OnSelect(BaseEventData e) {
        //Debug.Log("Select:" + e);
    }
    public virtual void OnUpdateSelected(BaseEventData e) {
        //Debug.Log("UpdateSelected:" + e); 
    }
    public virtual void OnDeselect(BaseEventData e) {
        //Debug.Log("Deselect:" + e);
    }
    public virtual void OnMove(AxisEventData e) {
        //Debug.Log("Move:" + e);
    }
    public virtual void OnPointerEnter(PointerEventData e) {
        //Debug.Log("PointerEnter:" + e);
    }
    public virtual void OnPointerDown(PointerEventData e) {
        //Debug.Log("PointerDown:" + e);
    }
    public virtual void OnPointerUp(PointerEventData e) {
        //Debug.Log("PointerUp:" + e);
    }
    public virtual void OnPointerClick(PointerEventData e) {
        //Debug.Log("PointerClick:" + e);
        Debug.Log("Click" + e);
    }
    public virtual void OnPointerExit(PointerEventData e) {
        //Debug.Log("PointerExit:" + e);
    }
    public virtual void OnDrag(PointerEventData e) {
        //Debug.Log("Drag:" + e); 
    }
    public virtual void OnDrop(PointerEventData e) {
        Debug.Log("Drop:" + e);
    }
    public virtual void OnScroll(PointerEventData e) {
        //Debug.Log("Scrill:" + e);
    }
}

