using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public ResourceManager Resource;
    public static GameManager Get;
    void Awake()
    {
        Get = this;
        Resource = transform.FindChild("ResourceManager").GetComponent<ResourceManager>();
        Resource.Initialize();
    }
}
