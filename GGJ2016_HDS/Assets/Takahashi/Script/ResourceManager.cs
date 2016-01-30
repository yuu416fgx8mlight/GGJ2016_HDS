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
        Sprite[] e = Resources.LoadAll<Sprite>("Texture/UI/NodeIcon");
        foreach (var i in e)
        {
            Textures.Add(i.name, i);
        }
    }

    //内部リソースの読み込み
    void LoadPrefab()
    {
        List<GameObject> gs = new List<GameObject>();
        gs.Add(Resources.Load<GameObject>("Window/CharacterWindow"));
        gs.Add(Resources.Load<GameObject>("Dialog/ShopDialog"));
		gs.Add(Resources.Load<GameObject>("Dialog/CollectionDialog"));
        gs.Add(Resources.Load<GameObject>("Node/EquipmentNode"));
        gs.Add(Resources.Load<GameObject>("Node/ReturnNode"));

        gs.Add(Resources.Load<GameObject>("Node/Image"));
        GameObject[] g = Resources.LoadAll<GameObject>("Equipment");
        foreach (var i in gs)
        {
            Prefabs.Add(i.name, i);
        }
        foreach(var i in g)
        {
            Prefabs.Add(i.name,i);
        }
    }
    public void Initialize()
    {
        LoadSprites();
        LoadPrefab();
    }
}
