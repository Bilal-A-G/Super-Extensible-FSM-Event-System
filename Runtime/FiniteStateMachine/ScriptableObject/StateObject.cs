using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "FSM/State Object")]
public class StateObject : ScriptableObject
{
    public List<EventObject> stateActions;

    public List<EventStatePairs> stateTransitions;

    public StateTreeObject stateChild;
}

[System.Serializable]
public struct EventStatePairs
{
    public EventObject action;
    public StateObject stateObject;
}
