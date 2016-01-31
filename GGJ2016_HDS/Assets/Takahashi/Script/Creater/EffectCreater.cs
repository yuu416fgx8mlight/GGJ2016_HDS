using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//コルーチンを使いたい！！
public class EffectCreater : MonoBehaviour
{  
    public static void CreateMoneyEffect(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("MoneyEffect"));
        g.transform.SetParent(parent,false);
    }
    public static void CreateMoneyEffect2(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("MoneyEffect2"));
        g.transform.SetParent(parent, false);

    }
    public static void CreateMoneyEffect3(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("MoneyEffect3"));
        g.transform.SetParent(parent, false);
    }
    public static void CreatePeckEffect(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("PeckEffect"));
        g.transform.SetParent(parent, false);
    }
    public static void CreatePeckEffect2(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("PeckEffect2"));
        g.transform.SetParent(parent, false);
    }
    public static void CreateShipment(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("Shipment"));
        g.transform.SetParent(parent, false);
    }
    public static void CreateShockwave(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("Shockwave"));
        g.transform.SetParent(parent, false);
    }
    public static void CreateSmokeEffect(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("SmokeEffect"));
        g.transform.SetParent(parent, false);
    }
    public static void CreateStrokeEffect(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("StrokeEffect"));
        g.transform.SetParent(parent, false);
    }
    public static void CreateStrokeEffect1(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("StrokeEffect1"));
        g.transform.SetParent(parent, false);
    }
    public static void CreateStrokeEffect2(Transform parent)
    {
        GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab("StrokeEffect2"));
        g.transform.SetParent(parent, false);
    }
    IEnumerator DelayAction(float delay,System.Action complete)
    {
        yield return new WaitForSeconds(delay);
        complete();
    }
}
