#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

[CustomEditor(typeof(StudentStartDataTable))]
[CanEditMultipleObjects]
public class StudentStartDataTableEditor : Editor
{
    private StudentStartDataTable _table = null;


    #region Inspector

    private void OnEnable()
    {
        _table = target as StudentStartDataTable;
    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Import Google Sheet"))
        {

            Debug.Log("로딩시작..");
            ImportGoogleSheet();
        }
    }

    #endregion


    #region LoadSheet

    private void ImportGoogleSheet()
    {


        GoogleSheetLoader googleSheet = new GoogleSheetLoader();

        StudentStartDataTableLoader loader = new StudentStartDataTableLoader();

        googleSheet.LoadSheet(_table.URL_ID, _table.URL_SHEET, (tsv) =>
        {
            loader.LoadSheet(tsv);
            OnFinishLoad(loader);
        });

    }


    private void OnFinishLoad(StudentStartDataTableLoader loader)
    {
        if (loader.StudentStartDataList.Count == 0)
        {
            Debug.Log("실패");
            return;
        }

        _table.StudentStartDataList = loader.StudentStartDataList;

        EditorUtility.SetDirty(_table);
        EditorApplication.ExecuteMenuItem("Assets/Refresh");
        Debug.Log("로드끝!");
    }

    #endregion

}


#region Parsing
public class StudentStartDataTableLoader
{
    public List<StudentStartData> StudentStartDataList = null;

    private static string ID = "ID";
    private static string NAME = "Name";
    private static string UNITY = "Unity";
    private static string CSHARP = "CSharp";
    private static string MBTI = "Mbti";
    private static string FAV_RESTAURANT = "FavRestaurant";
    private static string AFFINITY = "Affinity";
    private static string ICON = "Icon";

    private static string AFFINITY_CARROT = "당근";
    private static string SPRITE_NAME = "_Idle_18";
    public void LoadSheet(string tsv)
    {
        StudentStartDataList = new List<StudentStartData>();

        string[] rows = tsv.Split('\n');
        string[] itemNames = rows[0].Split('\t');

        for (int i = 1; i < rows.Length; i++)
        {
            string[] columns = rows[i].Split("\t");
            StudentStartData desc = new StudentStartData();

            for (int j = 0; j < columns.Length; j++)
            {
                if (itemNames[j] == ID)
                {
                    desc.ID = columns[j];
                    continue;
                }
                if (itemNames[j] == NAME)
                {
                    desc.Name = columns[j];
                    continue;
                }
                if (itemNames[j] == UNITY)
                {
                    desc.UnitySkill = int.Parse(columns[j]);
                    continue;
                }
                if (itemNames[j] == CSHARP)
                {
                    desc.CSharpSkill = int.Parse(columns[j]);
                    continue;
                }                
                if (itemNames[j] == MBTI)
                {
                    desc.MBTI = columns[j];
                    continue;
                }
                if (itemNames[j] == FAV_RESTAURANT)
                {
                    desc.FavRestaurant = columns[j];
                    continue;
                }
                if (itemNames[j] == AFFINITY)
                { 
                    string input = columns[j];
                    if (columns[j] == AFFINITY_CARROT)
                    {
                        desc.AffinityType = EAffinityType.Carrot;
                    }
                    else
                    {
                        desc.AffinityType = EAffinityType.Whip;
                    }
                    continue;
                }
                if (itemNames[j] == ICON)
                {
                    Object[] assets = AssetDatabase.LoadAllAssetsAtPath(columns[j]);
                    Sprite[] sprites = assets.OfType<Sprite>().ToArray();
                    int index = Array.FindIndex(sprites, sprite => sprite.name == desc.ID + SPRITE_NAME);
                    if (index == -1)
                    {
                        Debug.Log(sprites[0].name +" vs "+ desc.ID + SPRITE_NAME);
                        continue;
                    }
                    Sprite targetSprite = sprites[index]; 
                    desc.Icon = targetSprite;
                }
            }

            StudentStartDataList.Add(desc);
        }
    }
}
#endregion
#endif