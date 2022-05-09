using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    public SerializedDelegateEventPairs[] serializedDelegateEventPairs;
    public GameObject parentObject;

    protected void OnEnable()
    {
        for(int i = 0; i < serializedDelegateEventPairs.Length; i++)
        {
            for(int v = 0; v < serializedDelegateEventPairs[i].events.Count; v++)
            {
                serializedDelegateEventPairs[i].events[v].Subscribe(this);
            }
        }
    }

    protected void OnDisable()
    {
        for (int i = 0; i < serializedDelegateEventPairs.Length; i++)
        {
            for (int v = 0; v < serializedDelegateEventPairs[i].events.Count; v++)
            {
                serializedDelegateEventPairs[i].events[v].UnSubscribe(this);
            }
        }
    }

    public void OnInvoke(EventObject callingEvent)
    {
        for(int i = 0; i < serializedDelegateEventPairs.Length; i++)
        {
            for(int v = 0; v < serializedDelegateEventPairs[i].events.Count; v++)
            {
                if(serializedDelegateEventPairs[i].events[v] == callingEvent)
                {
                    serializedDelegateEventPairs[i].serializedDelegates.Invoke();
                }
            }
        }
    }
}

[System.Serializable]
public struct SerializedDelegateEventPairs
{
    public UnityEvent serializedDelegates;
    public List<EventObject> events;
}
