using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.IO;

[CustomEditor(typeof(EventObject))]
public class EventObjectEditor : Editor
{
    VisualTreeAsset customEditor;
    Button invokeEventButton;
    PropertyField arguments;

    EventObject currentEventObject;

    private void OnEnable()
    {
        var csScriptPath = AssetDatabase.GUIDToAssetPath("0a79c89479c2ab543965eb1a7013be37");
        var csFileName = Path.GetFileNameWithoutExtension(csScriptPath);
        var csDirectory = Path.GetDirectoryName(csScriptPath);

        customEditor = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>($"{csDirectory}/{csFileName}.uxml");
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
