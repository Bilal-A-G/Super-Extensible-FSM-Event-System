using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "State Objects")]
public class StateObject : ScriptableObject
{
    public List<EventResultPairs> stateActionResults;

    public List<EventStatePairs> stateTransitions;
}

[System.Serializable]
public struct EventStatePairs
{
    public EventObject action;
    public StateObject stateObject;
}

[System.Serializable]
public struct EventResultPairs
{
    public EventObject action;
    public Object result;
}
