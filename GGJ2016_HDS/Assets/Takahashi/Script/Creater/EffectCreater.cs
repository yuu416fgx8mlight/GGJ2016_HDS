using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//コルーチンを使いたい！！
public class EffectCreater : MonoBehaviour
{  
    IEnumerator DelayAction(float delay,System.Action complete)
    {
        yield return new WaitForSeconds(delay);
        complete();
    }
}
