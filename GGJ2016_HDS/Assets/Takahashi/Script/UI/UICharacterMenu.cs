using UnityEngine;
using System.Collections;

public class UICharacterMenu : UIController {

    void Awake()
    {
        transform.localPosition = new Vector2(CommonFile.ScreenWidth, 0);
    }
    void Start () {
        Init();
	}
}
