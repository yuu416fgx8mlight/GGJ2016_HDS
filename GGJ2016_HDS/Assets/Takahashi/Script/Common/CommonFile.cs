using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
#region delegate
public delegate void ControllFunc(System.Action func);

#endregion
public static class CommonFile{
    //FileNames
    public static readonly string SaveDataPath = Application.persistentDataPath + "/SaveData/";

    //ScreenSize
    public const int ScreenWidth = 540;
    public const int ScreenHeight = 960;

    public const int ScreenCenterX = 270;
    public const int ScreenCenterY = 480;

    public const string canvas = "Canvas";

}

public enum CanvasType
{
    GameCanvas,
    SubGameCanvas,
    UICanvas,
    UIFrontCanvas,
    UIBackCanvas,
    FrontCanvas,
}
