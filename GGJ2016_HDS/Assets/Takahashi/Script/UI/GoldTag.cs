using UnityEngine;
using System.Collections;

public class GoldTag : MonoBehaviour {

    void Start()
    {
        GameManager.Get.SetGoldTag(transform.FindChild("text").gameObject);
    }
}
