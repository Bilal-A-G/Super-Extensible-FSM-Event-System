using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface that denotes something is a finite state machine, all FSMs are responsible for transitioning
//their internal state and delegating calls from the actions to the current state
public interface IFiniteStateMachine
{
    //Update state method, called by the actions and updates the current state and
    //passes the arguments to the current state
    public void UpdateState(IFiniteStateMachine action, List<ResultArguments> arguments);
}
