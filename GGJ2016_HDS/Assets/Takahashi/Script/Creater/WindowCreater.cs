using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Sceneのプレハブを生成するクラス
//MonoBehaiviourは生成するために必要なので使用
public class WindowCreate {
    public static void CreateCharacterWindow(Transform parent)
    {
        GameObject g = MonoBehaviour.Instantiate(ResourceManager.Get.GetPrefab("CharacterWindow"));
        g.transform.SetParent(parent,false);
        g.GetComponent<UIController>().Init();
    }
}
