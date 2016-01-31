using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class EffectController : MonoBehaviour {
    private BloomOptimized bloom;

    public static EffectController Get;
    void Awake()
    {
        Get = this;
        bloom = GetComponent<BloomOptimized>();
    }

    public void BloomAnimation()
    {
       // float Threshold =;
    }
    
}
