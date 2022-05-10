using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelegateEventListener : EventListenerBase
{
    public SerializedDelegateEventPairs[] serializedDelegateEventPairs;
    public GameObject parentObject;

    protected override void SubscribeToEvents()
    {
        for (int i = 0; i < serializedDelegateEventPairs.Length; i++)
        {
            for (int v = 0; v < serializedDelegateEventPairs[i].events.Length; v++)
            {
                serializedDelegateEventPairs[i].events[v].Subscribe(this);
            }
        }
    }

    protected override void UnSubscribeFromEvents()
    {
        for (int i = 0; i < serializedDelegateEventPairs.Length; i++)
        {
            for (int v = 0; v < serializedDelegateEventPairs[i].events.Length; v++)
            {
                serializedDelegateEventPairs[i].events[v].UnSubscribe(this);
            }
        }
    }

    public override void OnInvoke(EventObject callingEvent, GameObject callingObject)
    {
        if (callingObject != parentObject && callingObject != null) return;

        for(int i = 0; i < serializedDelegateEventPairs.Length; i++)
        {
            for(int v = 0; v < serializedDelegateEventPairs[i].events.Length; v++)
            {
                if(serializedDelegateEventPairs[i].events[v] == callingEvent)
                {
                    for(int z = 0; z < serializedDelegateEventPairs[i].serializedDelegates.Length; z++)
                    {
                        serializedDelegateEventPairs[i].serializedDelegates[z].Execute();
                    }
                }
            }
        }
    }
}

[System.Serializable]
public struct SerializedDelegateEventPairs
{
    public ActionBase[] serializedDelegates;
    public EventObject[] events;
}
