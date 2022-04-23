using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ResultArguments
{
    public float floatValue;
    public int intValue;
    public string stringValue;
    public Vector3 vectorValue;
    public GameObject objectValue;

    [SerializeField]
    bool collapseGroup;

    public ResultArguments(float floatValue, int intValue, string stringValue, Vector3 vectorValue, GameObject objectValue)
    {
        this.floatValue = floatValue;
        this.intValue = intValue;
        this.stringValue = stringValue;
        this.vectorValue = vectorValue;
        this.objectValue = objectValue;

        collapseGroup = false;
    }
}
