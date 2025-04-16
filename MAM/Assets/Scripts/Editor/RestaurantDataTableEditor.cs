#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RestaurantTable))]
[CanEditMultipleObjects]
public class RestaurantTableEditor : Editor
{
    private RestaurantTable _table = null;


    #region Inspector

    private void OnEnable()
    {
        _table = target as RestaurantTable;
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

        RestaurantTableLoader loader = new RestaurantTableLoader();

        googleSheet.LoadSheet(_table.URL_ID, _table.URL_SHEET, (tsv) =>
        {
            loader.LoadSheet(tsv);
            OnFinishLoad(loader);
        });

    }


    private void OnFinishLoad(RestaurantTableLoader loader)
    {
        if (loader.RestaurantList.Count == 0)
        {
            Debug.Log("실패");
            return;
        }

        _table.RestaurantList = loader.RestaurantList;

        EditorUtility.SetDirty(_table);
        EditorApplication.ExecuteMenuItem("Assets/Refresh");
        Debug.Log("로드끝!");
    }

    #endregion

}

#region Parsing
public class RestaurantTableLoader
{
    public List<Restaurant> RestaurantList = null;

    private static string ID = "ID";
    private static string NAME = "Name";
    private static string ICON = "Icon";
    
    public void LoadSheet(string tsv)
    {
        RestaurantList = new List<Restaurant>();

        string[] rows = tsv.Split('\n');
        string[] itemNames = rows[0].Split('\t');

        for (int i = 1; i < rows.Length; i++)
        {
            string[] columns = rows[i].Split("\t");
            Restaurant desc = new Restaurant();

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
                if (itemNames[j] == ICON)
                {
                    desc.Icon = AssetDatabase.LoadAssetAtPath(columns[j], typeof(Sprite)) as Sprite;
                }
            }

            RestaurantList.Add(desc);
        }
    }
}
#endregion
#endif