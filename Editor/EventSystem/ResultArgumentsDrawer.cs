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

        SerializedProperty isGroupCollapsed = property.FindPropertyRelative("collapseGroup");

        SerializedProperty vectorValue = property.FindPropertyRelative("vectorValue");

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

            Vector3 inputVector = EditorGUILayout.Vector3Field(new GUIContent("Vector value"), vectorValue.vector3Value);
            vectorValue.vector3Value = inputVector;

            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndHorizontal();

    }
}
