using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Sceneのプレハブを生成するクラス
//MonoBehaiviourは生成するために必要なので使用
public class WindowCreate {
    public static void CreateCharacterWindow(Transform parent)
    {
        GameObject g = MonoBehaviour.Instantiate(GameManager.Get.Resource.GetPrefab("CharacterWindow"));
        g.transform.SetParent(parent,false);
        g.GetComponent<UIController>().Init();
    }
    public static void CreateHelp(Transform parent)
    {
        GameObject g = MonoBehaviour.Instantiate(GameManager.Get.Resource.GetPrefab("HelpWindow"));
        g.transform.SetParent(parent, false);
        g.GetComponent<UIController>().Init();
    }
}
