using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "State Objects")]
public class StateObject : ScriptableObject
{
    public bool consumeInput;

    public List<ActionResultPairs> stateActionResults;

    public List<ActionStatePairs> stateTransitions;
}

[System.Serializable]
public struct ActionStatePairs
{
    public Object action;
    public StateObject stateObject;
}

[System.Serializable]
public struct ActionResultPairs
{
    public Object action;
    public Object result;
}
