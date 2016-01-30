using UnityEngine;
using System.Collections;
using UnityEditor;

public class ResourcesSpriteToPrefab
{

    [MenuItem("Assets/SpriteToPrefab")]
    static void Function()
    {
        if (!System.IO.Directory.Exists("Assets/Resources"))
            AssetDatabase.CreateFolder("Assets", "Resources");

        foreach (var active in Selection.objects)
        {
            Sprite sprite = active as Sprite;
            if (sprite != null)
                SpriteToPrefab(sprite);
        }
    }

    static void SpriteToPrefab(Sprite sprite)
    {
        /// // プレハブを作る場合
        //GameObject obj = new GameObject(sprite.name);

        //var srender = obj.AddComponent<SpriteRenderer>();
        //srender.sprite = sprite;
        //PrefabUtility.CreatePrefab("Assets/Resources/" + sprite.name + ".prefab", obj);
        //GameObject.DestroyImmediate(obj);


        // スプライトアセットを作る場合
        Sprite s = Sprite.Create(sprite.texture, sprite.textureRect, sprite.textureRectOffset);
        AssetDatabase.CreateAsset(s, "Assets/Resources/" + sprite.name + ".asset");
        Debug.Log("Complete");

    }
}
