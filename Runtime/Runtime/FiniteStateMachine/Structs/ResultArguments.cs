using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Struct that supplies an IResults interface with arguments
public struct ResultArguments
{
    public float floatValue;
    public int intValue;
    public string stringValue;
    public Vector3 vectorValue;
    public GameObject objectValue;

    public ResultArguments(float floatValue, int intValue, string stringValue, Vector3 vectorValue, GameObject objectValue)
    {
        this.floatValue = floatValue;
        this.intValue = intValue;
        this.stringValue = stringValue;
        this.vectorValue = vectorValue;
        this.objectValue = objectValue;
    }
}
