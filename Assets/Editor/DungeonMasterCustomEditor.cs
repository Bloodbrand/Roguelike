using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(DungeonMaster))]
public class DungeonMasterCustomEditor : Editor
{
    DungeonMaster dm;
    SerializedObject GetTarget;
    SerializedProperty ThisList;
    int ListSize;

    string[] specialOptions = new string[] { "None", "Repeat", "Link" };

    void OnEnable()
    {
        dm = (DungeonMaster)target;
        GetTarget = new SerializedObject(dm);
        ThisList = GetTarget.FindProperty("PossibleRooms");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        //Update list
        GetTarget.Update();
        EditorGUILayout.Space();

        if (GUILayout.Button("Add New"))
        {
            dm.AddNewRoom();
        }

        EditorGUILayout.Space();

        //Display list to inspector 

        for (int i = 0; i < ThisList.arraySize; i++)
        {
            SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);
            SerializedProperty Name = MyListRef.FindPropertyRelative("Name");
            SerializedProperty Prefab = MyListRef.FindPropertyRelative("Prefab");
            SerializedProperty Probability = MyListRef.FindPropertyRelative("Probability");
            SerializedProperty StartFrom = MyListRef.FindPropertyRelative("StartFrom");
            SerializedProperty SelectedModifier = MyListRef.FindPropertyRelative("SelectedModifier");
            SerializedProperty NextRoom = MyListRef.FindPropertyRelative("NextRoom");
            SerializedProperty MaxRepeats = MyListRef.FindPropertyRelative("MaxRepeats");
            SerializedProperty Repeats = MyListRef.FindPropertyRelative("Repeats");
            SerializedProperty MaxSpawns = MyListRef.FindPropertyRelative("MaxSpawns");
            SerializedProperty Spawns = MyListRef.FindPropertyRelative("Spawns");

            EditorGUILayout.PropertyField(Name);
            EditorGUILayout.PropertyField(Prefab);
            EditorGUILayout.PropertyField(Probability);
            EditorGUILayout.PropertyField(StartFrom);
            EditorGUILayout.PropertyField(SelectedModifier);
            EditorGUILayout.LabelField("Chance", calculatePercentage(dm.PossibleRooms[i].Probability).ToString() + "%");

            dm.PossibleRooms[i].MaxSpawns = EditorGUILayout.Toggle("Max spawns", dm.PossibleRooms[i].MaxSpawns);
            if (dm.PossibleRooms[i].MaxSpawns) EditorGUILayout.PropertyField(Spawns);
            dm.PossibleRooms[i].SpecialOptionsIndex = EditorGUILayout.Popup("Special", dm.PossibleRooms[i].SpecialOptionsIndex, specialOptions);

            if (dm.PossibleRooms[i].SpecialOptionsIndex == 1) EditorGUILayout.PropertyField(Repeats);
            if (dm.PossibleRooms[i].SpecialOptionsIndex == 2) EditorGUILayout.PropertyField(NextRoom);
            if (GUILayout.Button("remove " + dm.PossibleRooms[i].Name)) ThisList.DeleteArrayElementAtIndex(i);

            //max repeats greater than max spawns
            if (dm.PossibleRooms[i].Repeats > dm.PossibleRooms[i].Spawns)
                dm.PossibleRooms[i].Repeats = dm.PossibleRooms[i].Spawns;
            
        }
        GetTarget.ApplyModifiedProperties();
    }

    double calculatePercentage(float probability)
    {
        double total = helpers.CalculateTotalProbabilityValue(dm.PossibleRooms);
        double percent = Math.Round((probability / total) * 100, 1);

        if(percent < 0 || float.IsNaN((float)percent)) return 0;
        else return percent;
    }
}

//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;

//[CustomEditor(typeof(CustomList))]

//public class CustomListEditor : Editor {

//    enum displayFieldType {DisplayAsAutomaticFields, DisplayAsCustomizableGUIFields}
//    displayFieldType DisplayFieldType;

//    CustomList t;
//    SerializedObject GetTarget;
//    SerializedProperty ThisList;
//    int ListSize;

//    void OnEnable(){
//        t = (CustomList)target;
//        GetTarget = new SerializedObject(t);
//        ThisList = GetTarget.FindProperty("MyList"); // Find the List in our script and create a refrence of it
//    }

//    public override void OnInspectorGUI(){
//        //Update our list

//        GetTarget.Update();

//        //Choose how to display the list<> Example purposes only
//        EditorGUILayout.Space ();
//        EditorGUILayout.Space ();
//        DisplayFieldType = (displayFieldType)EditorGUILayout.EnumPopup("",DisplayFieldType);

//        //Resize our list
//        EditorGUILayout.Space ();
//        EditorGUILayout.Space ();
//        EditorGUILayout.LabelField("Define the list size with a number");
//        ListSize = ThisList.arraySize;
//        ListSize = EditorGUILayout.IntField ("List Size", ListSize);

//        if(ListSize != ThisList.arraySize){
//            while(ListSize > ThisList.arraySize){
//                ThisList.InsertArrayElementAtIndex(ThisList.arraySize);
//            }
//            while(ListSize < ThisList.arraySize){
//                ThisList.DeleteArrayElementAtIndex(ThisList.arraySize - 1);
//            }
//        }

//        EditorGUILayout.Space ();
//        EditorGUILayout.Space ();
//        EditorGUILayout.LabelField("Or");
//        EditorGUILayout.Space ();
//        EditorGUILayout.Space ();

//        //Or add a new item to the List<> with a button
//        EditorGUILayout.LabelField("Add a new item with a button");

//        if(GUILayout.Button("Add New")){
//            t.MyList.Add(new CustomList.MyClass());
//        }

//        EditorGUILayout.Space ();
//        EditorGUILayout.Space ();

//        //Display our list to the inspector window

//        for(int i = 0; i < ThisList.arraySize; i++){
//            SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);
//            SerializedProperty MyInt = MyListRef.FindPropertyRelative("AnInt");
//            SerializedProperty Probability = MyListRef.FindPropertyRelative("AnFloat");
//            SerializedProperty MyVect3 = MyListRef.FindPropertyRelative("AnVector3");
//            SerializedProperty Mesh = MyListRef.FindPropertyRelative("AnGO");
//            SerializedProperty MyArray = MyListRef.FindPropertyRelative("AnIntArray");


//            // Display the property fields in two ways.

//            if(DisplayFieldType == 0){// Choose to display automatic or custom field types. This is only for example to help display automatic and custom fields.
//                //1. Automatic, No customization <-- Choose me I'm automatic and easy to setup
//                EditorGUILayout.LabelField("Automatic Field By Property Type");
//                EditorGUILayout.PropertyField(Mesh);
//                EditorGUILayout.PropertyField(MyInt);
//                EditorGUILayout.PropertyField(Probability);
//                EditorGUILayout.PropertyField(MyVect3);

//                // Array fields with remove at index
//                EditorGUILayout.Space ();
//                EditorGUILayout.Space ();
//                EditorGUILayout.LabelField("Array Fields");

//                if(GUILayout.Button("Add New Index",GUILayout.MaxWidth(130),GUILayout.MaxHeight(20))){
//                    MyArray.InsertArrayElementAtIndex(MyArray.arraySize);
//                    MyArray.GetArrayElementAtIndex(MyArray.arraySize -1).intValue = 0;
//                }

//                for(int a = 0; a < MyArray.arraySize; a++){
//                    EditorGUILayout.PropertyField(MyArray.GetArrayElementAtIndex(a));
//                    if(GUILayout.Button("Remove  (" + a.ToString() + ")",GUILayout.MaxWidth(100),GUILayout.MaxHeight(15))){
//                        MyArray.DeleteArrayElementAtIndex(a);
//                    }
//                }
//            }else{
//                //Or

//                //2 : Full custom GUI Layout <-- Choose me I can be fully customized with GUI options.
//                EditorGUILayout.LabelField("Customizable Field With GUI");
//                Mesh.objectReferenceValue = EditorGUILayout.ObjectField("My Custom Go", Mesh.objectReferenceValue, typeof(GameObject), true);
//                MyInt.intValue = EditorGUILayout.IntField("My Custom Int",MyInt.intValue);
//                Probability.floatValue = EditorGUILayout.FloatField("My Custom Float",Probability.floatValue);
//                MyVect3.vector3Value = EditorGUILayout.Vector3Field("My Custom Vector 3",MyVect3.vector3Value);


//                // Array fields with remove at index
//                EditorGUILayout.Space ();
//                EditorGUILayout.Space ();
//                EditorGUILayout.LabelField("Array Fields");

//                if(GUILayout.Button("Add New Index",GUILayout.MaxWidth(130),GUILayout.MaxHeight(20))){
//                    MyArray.InsertArrayElementAtIndex(MyArray.arraySize);
//                    MyArray.GetArrayElementAtIndex(MyArray.arraySize -1).intValue = 0;
//                }

//                for(int a = 0; a < MyArray.arraySize; a++){
//                    EditorGUILayout.BeginHorizontal();
//                    EditorGUILayout.LabelField("My Custom Int (" + a.ToString() + ")",GUILayout.MaxWidth(120));
//                    MyArray.GetArrayElementAtIndex(a).intValue = EditorGUILayout.IntField("",MyArray.GetArrayElementAtIndex(a).intValue, GUILayout.MaxWidth(100));
//                    if(GUILayout.Button("-",GUILayout.MaxWidth(15),GUILayout.MaxHeight(15))){
//                        MyArray.DeleteArrayElementAtIndex(a);
//                    }
//                    EditorGUILayout.EndHorizontal();
//                }
//            }

//            EditorGUILayout.Space ();

//            //Remove this index from the List
//            EditorGUILayout.LabelField("Remove an index from the List<> with a button");
//            if(GUILayout.Button("Remove This Index (" + i.ToString() + ")")){
//                ThisList.DeleteArrayElementAtIndex(i);
//            }
//            EditorGUILayout.Space ();
//            EditorGUILayout.Space ();
//            EditorGUILayout.Space ();
//            EditorGUILayout.Space ();
//        }

//        //Apply the changes to our list
//        GetTarget.ApplyModifiedProperties();
