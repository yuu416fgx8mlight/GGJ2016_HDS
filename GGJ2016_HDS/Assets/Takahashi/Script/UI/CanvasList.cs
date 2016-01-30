using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
[System.Serializable]
public class CanvasObject
{
    public GameObject canvas;
    public GameObject panel;
    public GameObject point;
    public CanvasType type;
    public void Set(GameObject canvas,CanvasType type)
    {
        this.canvas = canvas;
        panel = canvas.transform.FindChild("UIPanel").gameObject;
        point = panel.transform.FindChild("UIPoint").gameObject;
        this.type = type;
    }
}

public class CanvasList : MonoBehaviour {
    public static CanvasList Get;
    [SerializeField]
    private Dictionary<CanvasType, CanvasObject> canvas;
    [ContextMenu("Setting")]
    void Setting()
    {
        canvas = new Dictionary<CanvasType, CanvasObject>();
        GameObject[] g = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (var i in g)
        {
            foreach (CanvasType j in Enum.GetValues(typeof(CanvasType))){
                if (i.name == j.ToString())
                {
                    CanvasObject co = new CanvasObject();
                    co.Set(i,j);
                    canvas.Add(j, co);
                }
            }
        }
    }
    public CanvasObject GetCanvas(CanvasType type)
    {
        if (canvas.ContainsKey(type)) return canvas[type];
        return null;
    }
    void Awake()
    {
        Get = this;
        Setting();
    }

}
