using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface that denotes something as an action. Actions gather input and sends data to the FSM
//so the current state can act on it
public abstract class AAction : MonoBehaviour
{
    protected IFiniteStateMachine fsm;

    protected List<ResultArguments> arguments;

    protected Transform player;

    private void Awake()
    {
        player = transform.parent;

        fsm = player.GetComponentInChildren<IFiniteStateMachine>();
        arguments = new List<ResultArguments>();
    }

    protected void AddArgument(ResultArguments argument)
    {
        if (!arguments.Contains(argument))
        {
            arguments.Add(argument);
        }
    }

    protected void RemoveAllArguments()
    {
        arguments.Clear();
    }

}
