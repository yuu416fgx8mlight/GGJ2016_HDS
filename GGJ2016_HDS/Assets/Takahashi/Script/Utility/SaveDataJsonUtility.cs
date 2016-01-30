using System.Collections;
using UnityEngine;
using System.IO;
using System;
using System.Reflection;
using MiniJSON;

public class SaveDataJsonUtility: ISerializationCallbackReceiver
{
    public static bool Save<T>(T obj,string filename)
    {
        if (!Directory.Exists(CommonFile.SaveDataPath))
        {
            Directory.CreateDirectory(CommonFile.SaveDataPath);
            return false;
        }
        string jsontext = JsonUtility.ToJson(obj,true);

        //PlayerPrefs.SetString(filename, jsontext);
        File.WriteAllText(CommonFile.SaveDataPath + filename + ".json",jsontext);
        return true;
    }
    public static T Load<T>(string filename)
    {
        string filepath = CommonFile.SaveDataPath + filename + ".json";
        if (!File.Exists(filepath))
        {
            Debug.Log("[SAVEDATAJSON:LOAD]:NULL");
            return default(T);
        }
        string jsontext = File.ReadAllText(filepath);
        //string jsontext = PlayerPrefs.GetString(filename);
        T result = JsonUtility.FromJson<T>(jsontext);
        return result;
    }
    public static string EncryptionWord(string s)
    {
        string result = s;

        return result;
    }
    /// <summary>
    /// Json化時に実行してくれる
    /// </summary>
    public void OnBeforeSerialize()
    {

    }

    /// <summary>
    /// Jsonからデシリアライズされたあとに実行される
    /// </summary>
    public void OnAfterDeserialize()
    {
        
    }

}