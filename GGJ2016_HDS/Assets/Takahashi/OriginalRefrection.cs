using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
public enum BindType
{
    Public=BindingFlags.Public,
    NonPublic=BindingFlags.NonPublic,
    Instance=BindingFlags.Instance,
    Static=BindingFlags.Static,
    DeclaredOnly=BindingFlags.DeclaredOnly,
    Field=BindingFlags.SetField,
    Property=BindingFlags.SetProperty,
    All = BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static
}
public class OriginalRefrection { 
    private static readonly Type[] typelist =
    {
        //System
        typeof(void),
        typeof(bool),typeof(byte),typeof(sbyte),typeof(char),typeof(decimal),
        typeof(double),typeof(double),typeof(float),typeof(int),typeof(uint),
        typeof(long),typeof(ulong),typeof(object),typeof(short),typeof(ushort),
        typeof(string),
        //Unity
        typeof(GameObject),typeof(Transform),typeof(Component)
    };
    private const BindingFlags defaultbind = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static| BindingFlags.Instance|BindingFlags.DeclaredOnly;
    private static BindingFlags bind = defaultbind;

    public static void SetBindType(BindType type)
    {
        bind = (BindingFlags)type;
    }
    public static void SetField(object self,string key,object data)
    {
        FieldInfo info = self.GetType().GetField(
            key,bind );
        foreach(Type t in typelist)
        {
            if(info.FieldType== t)
            {
                info.SetValue(self, Convert.ChangeType(data, t));
                break;
            }
        }
    }
    public static void SetProperty(object self,string key, object data)
    {

        // プロパティ名をキーにプロパティを取得
        PropertyInfo propertyInfo = self.GetType().GetProperty(
            key, bind);
        if (propertyInfo == null) return;
        foreach (Type t in typelist)
        {
            if(propertyInfo.PropertyType== t)
            {
                propertyInfo.SetValue(self, Convert.ChangeType(data,t),null);
            }
        }
    }
    public static void RunMethod(object self,string key,params object[] param)
    {
        MethodInfo methodInfo = self.GetType().GetMethod(
            key, bind);
        if (methodInfo == null) return;
        methodInfo.Invoke(self, param);
    }
    public static List<string> SelfFieldToStrings(object self)
    {
        List<string> sv = new List<string>();
        foreach(var i in self.GetType().GetFields(bind))
        {
            sv.Add(i.Name);
        }
        return sv;
    }
    public static List<string> SelfPropertyToString(object self)
    {
        List<string> sv = new List<string>();
        foreach (var i in self.GetType().GetProperties(bind))
        {
            sv.Add(i.Name);
        }
        return sv;
    }
    public static List<string> SelfMethodToString(object self)
    {
        List<string> sv = new List<string>();
        foreach (var i in self.GetType().GetMethods(bind))
        {
            sv.Add(i.Name);
        }
        return sv;
    }
}
