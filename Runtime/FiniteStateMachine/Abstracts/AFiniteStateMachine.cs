using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface that denotes something is a finite state machine, all FSMs are responsible for transitioning
//their internal state and delegating calls from the actions to the current state
public abstract class AFiniteStateMachine : MonoBehaviour
{
    protected State currentState;

    //Update state method, called by the actions and updates the current state and
    //passes the arguments to the current state
    public virtual void UpdateState(AAction action, List<ResultArguments> arguments)
    {
        Debug.LogError("This class is attempting to use default FSM behaviour which is undefined, this is not allowed");
    }

    protected void DelegateToChild(AAction action, List<ResultArguments> arguments)
    {
        AFiniteStateMachine childStateMachine = transform.GetChild(0).GetComponent<AFiniteStateMachine>();
        if(childStateMachine != null)
        {
            childStateMachine.UpdateState(action, arguments);
        }
    }
}
