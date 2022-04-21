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

        for (int i = 0; i < currentState.stateActionResults.Count; i++)
        {
            if (action == currentState.stateActionResults[i].action)
            {
                UnityEditor.MonoScript currentStateLogic = (UnityEditor.MonoScript)currentState.stateActionResults[i].result;
                System.Type currentStateLogicType = currentStateLogic.GetClass();

                object[] convertedArguments = new object[arguments.Count];
                convertedArguments[0] = arguments;

                currentStateLogicType.GetMethod("Execute").Invoke(currentStateLogicType, convertedArguments);

                return;
            }
        }

        DelegateToChild(action, arguments);
    }

    void DelegateToChild(EventObject action, List<ResultArguments> arguments)
    {
        FiniteStateMachine childStateMachine = transform.GetChild(0).GetComponent<FiniteStateMachine>();
        if(childStateMachine != null)
        {
            childStateMachine.UpdateState(action, arguments);
        }
    }
}
