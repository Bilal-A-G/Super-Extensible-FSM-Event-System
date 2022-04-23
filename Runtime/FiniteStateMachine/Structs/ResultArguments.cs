using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ResultArguments
{
    public float floatValue;
    public int intValue;
    public string stringValue;
    [HideInInspector]
    public Vector3 vectorValue { get { return new Vector3(tuplex, tupley, tuplez); }}
    public GameObject objectValue;

    [SerializeField]
    float tuplex;
    [SerializeField]
    float tupley;
    [SerializeField]
    float tuplez;

    [SerializeField]
    bool isCollapsed;
    [SerializeField]
    bool collapseGroup;

    public ResultArguments(float floatValue, int intValue, string stringValue, Vector3 vectorValue, GameObject objectValue)
    {
        this.floatValue = floatValue;
        this.intValue = intValue;
        this.stringValue = stringValue;
        tuplex = vectorValue.x;
        tupley = vectorValue.y;
        tuplez = vectorValue.z;
        this.objectValue = objectValue;

        isCollapsed = false;
        collapseGroup = false;
    }

    public void SetVector3Value(Vector3 newValue)
    {
        tuplex = newValue.x;
        tupley = newValue.y;
        tuplez = newValue.z;
    }
}
