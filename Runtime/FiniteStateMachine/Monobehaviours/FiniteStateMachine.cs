using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    public StateObject currentState;

    public void UpdateState(EventObject action, List<ResultArguments> arguments)
    {
        for (int i = 0; i < currentState.stateTransitions.Count; i++)
        {
            if (action == currentState.stateTransitions[i].action)
            {
                currentState = currentState.stateTransitions[i].stateObject;
                break;
            }
        }

        for (int i = 0; i < currentState.stateActions.Count; i++)
        {
            if (action == currentState.stateActions[i])
            {
                action.Invoke(arguments);
                return;
            }
        }

        DelegateToChild(action, arguments);
    }

    void DelegateToChild(EventObject action, List<ResultArguments> arguments)
    {
        if (transform.childCount == 0) return;

        FiniteStateMachine childStateMachine = transform.GetChild(0).GetComponent<FiniteStateMachine>();
        if(childStateMachine != null)
        {
            childStateMachine.UpdateState(action, arguments);
        }
    }
}
