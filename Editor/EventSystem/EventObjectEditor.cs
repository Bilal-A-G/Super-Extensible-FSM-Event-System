using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomEditor(typeof(EventObject))]
public class EventObjectEditor : Editor
{
    VisualTreeAsset customEditor;
    Button invokeEventButton;
    PropertyField arguments;

    EventObject currentEventObject;

    private void OnEnable()
    {
        customEditor = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Editor/EventSystem/EventObjectTree.uxml");
        currentEventObject = (EventObject)target;
    }

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement rootVisualElement = new VisualElement();
        customEditor.CloneTree(rootVisualElement);

        invokeEventButton = rootVisualElement.Q<Button>("InvokeEvent");
        arguments = rootVisualElement.Q<PropertyField>("Arguments");

        arguments.BindProperty(serializedObject.FindProperty("argumentsList"));

        invokeEventButton.clicked += OnEventInvoked;

        return rootVisualElement;
    }

    void OnEventInvoked()
    {
        currentEventObject.InvokeInEditor();
    }
}
