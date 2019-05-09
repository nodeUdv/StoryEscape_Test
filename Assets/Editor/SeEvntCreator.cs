using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SeEvntCreator
{
    #region ACTIONS
        [MenuItem("StoryEscape/Create/Actions/ChangePlayerState")]
        public static void Create_ChangePlayerState()
        {
            SeAction_ChangePlayerState asset = ScriptableObject.CreateInstance<SeAction_ChangePlayerState>();
            CreateInAssetsAndSelect (asset, "Playables/Actions/Action_PlayerState.asset");
        }
        [MenuItem("StoryEscape/Create/Actions/GetObject")]
        public static void Create_GetObject()
        {
            SeAction_GetObject asset = ScriptableObject.CreateInstance<SeAction_GetObject>();
            CreateInAssetsAndSelect(asset, "Playables/Actions/Action_GetObject.asset");
        }
    #endregion
    #region CONDITIONS
        [MenuItem("StoryEscape/Create/Conditions/HasObject")]
        public static void Create_HasObject()
        {
            SeCondition_HasObject asset = ScriptableObject.CreateInstance<SeCondition_HasObject>();
            CreateInAssetsAndSelect(asset, "Playables/Conditions/Condition_HasObject.asset");
        }
    #endregion
    #region OBJECTS
        [MenuItem("StoryEscape/Create/Objects/CreateEmpty")]
        public static void Create_EmptyObject()
        {
            SeSimpleObject asset = ScriptableObject.CreateInstance<SeSimpleObject>();
            CreateInAssetsAndSelect(asset, "Playables/Objects/Object_Simple.asset");
        }
    #endregion
    #region EDITOR
        [MenuItem("StoryEscape/Tools/Reset PlayerPrefs %p")]
        public static void Reset_PlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    #endregion

    #region Helpers
    private static void CreateInAssetsAndSelect (Object a, string at)
    {
        AssetDatabase.CreateAsset(a, "Assets/" + at);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = a;
    }
    #endregion
}
