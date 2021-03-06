﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentNode : MonoBehaviour {
    //とりあえずつかうときに使う
    public MasterShop.param info;
    public EquipmentType type;
    public Transform equipparent;

    public void NodeClick(EquipmentGridType type,EquipmentGrid grid,MasterShop.param data)
    {
        CommonFile.push();
        if (type == EquipmentGridType.Category)
        {
			grid.ChangeGrid(EquipmentGridType.Item,this.type);
        }

        if (type == EquipmentGridType.Item)
        {
            int category = data.category;
            DialogCreater.CreateShopDialog(CanvasList.Get.GetCanvas(CanvasType.FrontCanvas).point.transform,
				data,()=> { SetEquipment((EquipmentType)data.category,data.res,data.GetColor(),data); });
			
        }

    }
	public void SetEquipment(EquipmentType type,string res,Color c,MasterShop.param data)
    {
		
		if (EquipmentType.Hand == type)
		{
			switch(data.gread){
			case 0://撫でる
				GameObject.FindGameObjectWithTag("Player").GetComponent<EggStatus>().Hot+=data.hot;
				break;
			case 1://つく
				GameObject.FindGameObjectWithTag("Player").GetComponent<EggStatus>().Stres+=data.stress;
				break;
			case 2://割る
				GameObject.FindGameObjectWithTag("Player").GetComponent<EggStatus>().EggHP-=1;
                EffectCreater.CreateShockwave(EquipmentPointSystem.Get.HandPoint);
				break;
			}
        }
        if (EquipmentType.Lag == type)
        {
            GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab(res)) as GameObject;
            g.transform.localScale = new Vector3(0, 1, 1);
            g.GetComponent<Image>().color = c;
            g.transform.SetParent(EquipmentPointSystem.Get.LagPiont, false);
            g.GetComponent<Equipment>().SetParam(data);
            LeanTween.scaleX(g, 1, 0.2f);

        }
        if (EquipmentType.Light == type)
        {
            //ライトの処理
            GameObject g = Instantiate(GameManager.Get.Resource.GetPrefab(res)) as GameObject;
            Vector2 pos = g.transform.localPosition;
            g.transform.localPosition = g.transform.localPosition + new Vector3(-200, 0,0);
            g.GetComponent<Image>().color = c;
            g.transform.SetParent(EquipmentPointSystem.Get.LightPoint, false);
            g.GetComponent<Equipment>().SetParam(data);
            LeanTween.moveLocal(g, pos, 0.2f);
        }
        if(EquipmentType.Drag== type)
        {
            //ドラッグの処理
            EggStatus states = GameObject.FindGameObjectWithTag("Player").GetComponent<EggStatus>();
            EffectCreater.CreateStrokeEffect2(EquipmentPointSystem.Get.HandPoint);
            states.Hot += data.hot;
            states.Stres += data.stress;
        }
    }
}
