using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SaveManager))]
public class SaveManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SaveManager myScript = (SaveManager)target;

        //if(serializedObject.FindProperty("savedObjects") != null)
        //{
        //    EditorGUILayout.HelpBox(serializedObject.FindProperty("savedObjects").stringValue, MessageType.Info);
        //
        //}
        if (GUILayout.Button("Save State"))
        {
            myScript.UpdateAllStates();
        }
        if (GUILayout.Button("Load State"))
        {
            myScript.LoadFromSaved();
        }
    }

}