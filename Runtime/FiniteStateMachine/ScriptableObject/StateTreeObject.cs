using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tree", menuName = "FSM/State Tree Object")]
public class StateTreeObject : ScriptableObject
{
    [SerializeField]
    StateObject initialState;

    StateObject currentState;

    private void OnEnable()
    {
        currentState = initialState;
    }

    public void UpdateState(EventObject action, GameObject callingObject)
    {
        for(int i = 0; i < currentState.stateTransitions.Count; i++)
        {
            if(currentState.stateTransitions[i].action == action)
            {
                currentState = currentState.stateTransitions[i].stateObject;
                break;
            }
        }

        for (int i = 0; i < currentState.stateActions.Count; i++)
        {
            if (action == currentState.stateActions[i].action)
            {
                currentState.stateActions[i].GetTranslatedEvent().Invoke(callingObject);
                break;
            }
        }

        if(currentState.stateChild == null) return;

        currentState.stateChild.UpdateState(action, callingObject);
    }
}
