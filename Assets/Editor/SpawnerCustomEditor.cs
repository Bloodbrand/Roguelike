using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(Spawner))]
public class SpawnerCustomEditor : Editor
{
    Spawner spawner;
    SerializedObject GetTarget;
    SerializedProperty ThisList;

    void OnEnable()
    {
        spawner = (Spawner)target;
        GetTarget = new SerializedObject(spawner);
        ThisList = GetTarget.FindProperty("Props");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GetTarget.Update();
        EditorGUILayout.Space();

        for (int i = 0; i < ThisList.arraySize; i++)
        {   
            SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);
            SerializedProperty Prefab = MyListRef.FindPropertyRelative("Prefab");
            SerializedProperty Probability = MyListRef.FindPropertyRelative("Probability");
        }

        GetTarget.ApplyModifiedProperties();
    }
}
