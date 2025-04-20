using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.Animation;
using System.IO;
using System.Linq;

public class StudentSpriteLibraryGenerator : EditorWindow
{
    private static string _libraryPath = "Assets/SpriteLibraries/Char1Library.spriteLib";
    private SpriteLibraryAsset _baseLibrary = null;
    
    private string _characterName = "NewCharacter";
    private string _ouputFolder = "Assets/SpriteLibraries";

    private Texture2D _idleSheet = null;

    [MenuItem("Tools/Student Sprite Library Generator")]
    public static void ShowWindow()
    {
        GetWindow<StudentSpriteLibraryGenerator>("Student Sprite Library Generator");
    }

    private void OnEnable()
    {
        _baseLibrary = AssetDatabase.LoadAssetAtPath<SpriteLibraryAsset>(_libraryPath);
    }

    private void OnGUI()
    {
        GUILayout.Label("Generate SpriteLibraryAsset", EditorStyles.boldLabel);
        
        _characterName = EditorGUILayout.TextField("Character Name", _characterName);
        _ouputFolder = EditorGUILayout.TextField("Output Folder", _ouputFolder);

        EditorGUILayout.Space();
        
        _idleSheet = EditorGUILayout.ObjectField("Idle Sheet", _idleSheet, typeof(Texture2D), false) as Texture2D;
        
        EditorGUILayout.Space();
        
        if (GUILayout.Button("Generate"))
        {
            GenerateLibrary();
        }
    }

    private void GenerateLibrary()
    {
        if (_idleSheet == null)
        {
            Debug.LogError("No idle sheet selected");
            return;
        }

        if (_baseLibrary == null)
        {
            Debug.LogError("Cannot find baseLibrary");
        }
        
        //baseLibrary 복사
        SpriteLibraryAsset newLib = Object.Instantiate(_baseLibrary);
        newLib.name = _characterName + "Library";
        
        //시트안의 스프라이트 가져오기
        string sheetPath = AssetDatabase.GetAssetPath(_idleSheet);
        var sprites = AssetDatabase.LoadAllAssetsAtPath(sheetPath)
            .OfType<Sprite>()
            .ToArray();
        
        
        //카테고리 / 레이블에 덮어쓰기
        int spriteIndex = 0;
        
        string category = "Idle_Left";
        for (int i = 0; i < 6; i++)
        {
            newLib.RemoveCategoryLabel(category,$"Idle_Left_{i}",false);
            newLib.AddCategoryLabel(sprites[spriteIndex],category,$"Idle_Left_{i}");
            
            spriteIndex++;
        }
        
        category = "Idle_Back";
        for (int i = 0; i < 6; i++)
        {
            newLib.RemoveCategoryLabel(category,$"Idle_Back_{i}",false);
            newLib.AddCategoryLabel(sprites[spriteIndex],category,$"Idle_Back_{i}");
            spriteIndex++;
        }
        
        category = "Idle_Right";
        for (int i = 0; i < 6; i++)
        {
            newLib.RemoveCategoryLabel(category,$"Idle_Right_{i}",false);
            newLib.AddCategoryLabel(sprites[spriteIndex],category,$"Idle_Right_{i}");
            spriteIndex++;
        }
        
        category = "Idle_Front";
        for (int i = 0; i < 6; i++)
        {
            newLib.RemoveCategoryLabel(category,$"Idle_Front_{i}",false);
            newLib.AddCategoryLabel(sprites[spriteIndex],category,$"Idle_Front_{i}");
            spriteIndex++;
        }
        
        
        //저장
        string path = $"{_ouputFolder}/{_characterName}Library.asset";
        AssetDatabase.CreateAsset(newLib, path);
        AssetDatabase.SaveAssets();
        Debug.Log("Asset Created");
    }
}
