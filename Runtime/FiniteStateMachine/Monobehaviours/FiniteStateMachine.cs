using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    public StateTreeObject initialState;

    public void UpdateState(EventObject action, List<ResultArguments> arguments) => initialState.UpdateState(action, arguments);
}
