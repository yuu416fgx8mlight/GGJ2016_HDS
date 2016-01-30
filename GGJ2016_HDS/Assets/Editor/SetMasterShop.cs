using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

using System.Collections.Generic;
public class SetMasterShop : AssetPostprocessor
{

    private static readonly string fileDir = "Assets/Resources/MasterData/MasterShop.xls";
	private static readonly string exportDir = "Assets/Resources/MasterData/Data";

	static void LoadMissionData(string path,MasterShop data)
	{
		using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
		{
			IWorkbook book = new HSSFWorkbook(stream);

			ISheet sheet = book.GetSheetAt(0);
			Debug.Log(sheet.SheetName);

            IRow row0 = sheet.GetRow(0);

            //一番最初のフィールドは見出しなので無視
            for (int i = 1; i < sheet.LastRowNum; i++)
            {

                IRow row = sheet.GetRow(i);
                //エクセルデータを編集したらこことMasterCharacterに追加すれば更新できるよ
                MasterShop.Cell p = new MasterShop.Cell();
                p.id = (int)row.GetCell(0).NumericCellValue;
                p.name = row.GetCell(1).StringCellValue;
                p.subscripsion = row.GetCell(2).StringCellValue;
                p.gold = (int)row.GetCell(3).NumericCellValue;
                p.hot = (int)row.GetCell(4).NumericCellValue;
                p.stress = (int)row.GetCell(5).NumericCellValue;
                p.category = (int)row.GetCell(6).NumericCellValue;
                data.list.Add(p);
            }

        }
	}
	
	// 1
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {

			//インポートされたファイルがfileDirの位置か
			if (!asset.Contains(fileDir))
				continue;

			if (asset.LastIndexOf(".xls") == -1) continue;

			int idx = asset.LastIndexOf("/");
			var assetpath = exportDir + asset.Substring(idx)+".asset";
            MasterShop data = (MasterShop)AssetDatabase.LoadAssetAtPath(assetpath, typeof(MasterShop));

			//アセットがなければ作成
			if (data == null)
			{
				data = ScriptableObject.CreateInstance<MasterShop>();
				AssetDatabase.CreateAsset((ScriptableObject)data, assetpath);
				data.hideFlags = HideFlags.NotEditable;
			}

			data.list.Clear();
			LoadMissionData(asset, data);

			ScriptableObject obj = AssetDatabase.LoadAssetAtPath (
				assetpath, typeof(ScriptableObject)) as ScriptableObject;

			if (obj == null)
				continue;

			obj.hideFlags = HideFlags.NotEditable;

			EditorUtility.SetDirty (obj);
		}
	}
}