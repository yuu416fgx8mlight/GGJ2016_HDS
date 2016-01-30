using UnityEngine;
using System.Collections;


public class UIHelpWindow : MonoBehaviour {

    private Transform m_content;

    public string[] iconres =
    {
        "tutuku_0","naderu_0","waru_0","Light_0","Mat_0"
    };

    void Start()
    {
        m_content = transform.FindChild("ScrollView/Content");

    }
    
}
