using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ResultArguments))]
public class ResultArgumentsDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty floatValue = property.FindPropertyRelative("floatValue");
        SerializedProperty intValue = property.FindPropertyRelative("intValue");
        SerializedProperty stringValue = property.FindPropertyRelative("stringValue");
        SerializedProperty objectValue = property.FindPropertyRelative("objectValue");

        SerializedProperty isCollapsed = property.FindPropertyRelative("isCollapsed");
        SerializedProperty isGroupCollapsed = property.FindPropertyRelative("collapseGroup");

        SerializedProperty tuplexValue = property.FindPropertyRelative("tuplex");
        SerializedProperty tupleyValue = property.FindPropertyRelative("tupley");
        SerializedProperty tuplezValue = property.FindPropertyRelative("tuplez");

        if (EditorGUILayout.Foldout(isGroupCollapsed.boolValue, new GUIContent(label)))
        {
            isGroupCollapsed.boolValue = true;
        }
        else
        {
            isGroupCollapsed.boolValue = false;
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space();

        if (isGroupCollapsed.boolValue)
        {
            EditorGUILayout.BeginVertical();

            EditorGUILayout.PropertyField(floatValue, new GUIContent("Float value"));
            EditorGUILayout.PropertyField(intValue, new GUIContent("Int value"));
            EditorGUILayout.PropertyField(stringValue, new GUIContent("String value"));
            EditorGUILayout.PropertyField(objectValue, new GUIContent("Object value"));

            if (EditorGUILayout.Foldout(isCollapsed.boolValue, new GUIContent("Vector3 value")))
            {
                isCollapsed.boolValue = true;
            }
            else
            {
                isCollapsed.boolValue = false;
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();

            if (isCollapsed.boolValue)
            {
                EditorGUILayout.BeginVertical();
                EditorGUILayout.PropertyField(tuplexValue, new GUIContent("X"));
                EditorGUILayout.PropertyField(tupleyValue, new GUIContent("Y"));
                EditorGUILayout.PropertyField(tuplezValue, new GUIContent("Z"));
                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndHorizontal();

    }
}
