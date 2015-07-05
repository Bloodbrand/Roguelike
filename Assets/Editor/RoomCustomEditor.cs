//using UnityEngine;
//using UnityEditor;
//using System.Collections;

//[CustomEditor(typeof(Room))]
//public class RoomCustomEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        MonoBehaviour a = (MonoBehaviour)target;
//       Room roomTarget = (Room)target;

//        myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
        
//        EditorGUILayout.LabelField("Level", roomTarget.probability.ToString());
//    }
//}