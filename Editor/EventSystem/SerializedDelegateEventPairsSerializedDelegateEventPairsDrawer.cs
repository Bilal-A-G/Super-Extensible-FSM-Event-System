using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CustomPropertyDrawer(typeof(SerializedDelegateEventPairs))]
public class SerializedDelegateEventPairsDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var serializedEvents = property.FindPropertyRelative("events");
        var serializedDelegates = property.FindPropertyRelative("serializedDelegates");

        EditorGUI.PropertyField(new Rect(position.x + position.width/2, position.y, position.width/2, position.height), serializedEvents, new GUIContent("Events"));
        EditorGUI.PropertyField(new Rect(position.x - position.x/2.1f, position.y, position.width/2, position.height), serializedDelegates, new GUIContent("Delegates"));

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float startingLines = 5;

        float eventLines = 0;
        float delegateLines = 0;

        float greaterLines;

        var serializedEvents = property.FindPropertyRelative("events");
        var serializedDelegates = property.FindPropertyRelative("serializedDelegates");

        var obj = fieldInfo.GetValue(serializedDelegates.serializedObject.targetObject);
        SerializedDelegateEventPairs resultEvent = new SerializedDelegateEventPairs();

        if (obj.GetType().IsArray)
        {
            var index = Convert.ToInt32(new string(property.propertyPath.Where(c => char.IsDigit(c)).ToArray()));
            resultEvent = ((SerializedDelegateEventPairs[])obj)[index];
        }

        for (int i = 0; i < resultEvent.serializedDelegates.GetPersistentEventCount() - 1; i++)
        {
            delegateLines+=2.5f;
        }

        for (int i = 0; i < serializedEvents.arraySize - 1; i++)
        {
            eventLines++;
        }


        if (eventLines > startingLines - 4 && eventLines - 1 > delegateLines)
        {
            greaterLines = eventLines - 1;
        }
        else
        {
            greaterLines = delegateLines;
        }

        return EditorGUIUtility.singleLineHeight * (startingLines + greaterLines) + EditorGUIUtility.standardVerticalSpacing * ((startingLines + greaterLines) - 1);
    }

    void OnEnable()
    {

    }

    private void OnDisable()
    {
        
    }
}


