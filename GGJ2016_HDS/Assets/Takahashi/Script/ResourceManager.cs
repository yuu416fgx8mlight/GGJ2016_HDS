using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour {
    //スプライトデータを格納する場所
    private Dictionary<string, Sprite> Textures = new Dictionary<string, Sprite>();
    //AudioClipを格納する場所
    //private Dictionary<string, AudioClip> Audios = new Dictionary<string, AudioClip>();
    //プレハブデータを格納する場所
    private Dictionary<string, GameObject> Prefabs = new Dictionary<string, GameObject>();
    public GameObject GetPrefab(string name)
    {
        if (Prefabs.ContainsKey(name)) return Prefabs[name];
        return null;
    }
    public Sprite GetTexture(string name)
    {
        if (Textures.ContainsKey(name)) return Textures[name];
        return null;
    }
    void LoadSprites()
    {
        //Sprite[] e=Resources.LoadAll<Sprite>("Textures/Enemy");
        //foreach(var i in e)
        //{
        //    Textures.Add(i.name, i);
        //}
    }

    //内部リソースの読み込み
    void LoadPrefab()
    {
        List<GameObject> gs = new List<GameObject>();
        gs.Add(Resources.Load<GameObject>("Window/CharacterWindow"));
        gs.Add(Resources.Load<GameObject>("Dialog/ShopDialog"));

        foreach (var i in gs)
        {
            Prefabs.Add(i.name, i);
        }
    }
    public void Initialize()
    {
        LoadSprites();
        LoadPrefab();
    }
    //とりあえずテスト用
    public static ResourceManager Get;
    void Awake()
    {
        Get = this;
        Initialize();
    }
}
