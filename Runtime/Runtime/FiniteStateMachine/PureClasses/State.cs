using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class that holds the actions the state can act on and the results of those actions
public class State
{
    //Dictionary containing which actions this state can respond to and what happens
    //when a specific action calls this state
    List<KeyValuePair<AAction, IResult>> actionResultList;

    //Passing in a new dictionary of actions and results
    public State(List<KeyValuePair<AAction, IResult>> actionResultList)
    {
        this.actionResultList = actionResultList;
    }

    //Execute method, called by the FSM, retuns a bool that the FSM will use to determine
    //wheather to delegate the action downwards or not
    public bool Execute(AAction action, List<ResultArguments> arguments)
    {
        for (int i = 0; i < actionResultList.Count; i++)
        {
            if (actionResultList[i].Key.GetType() == action.GetType())
            {
                actionResultList[i].Value.Execute(arguments);
                return true;
            }
        }
        return false;
    }
}
