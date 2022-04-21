using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event Objects")]
public class EventObject : ScriptableObject
{
    List<EventListener> subscribedListeners = new List<EventListener>();

    public void Subscribe(EventListener listener)
    {
        if (!subscribedListeners.Contains(listener))
        {
            subscribedListeners.Add(listener);
        }
    }

    public void UnSubscribe(EventListener listener)
    {
        if (subscribedListeners.Contains(listener))
        {
            subscribedListeners.Remove(listener);
        }
    }

    public void Invoke(List<ResultArguments> arguments)
    {
        for(int i = 0; i < subscribedListeners.Count; i++)
        {
            subscribedListeners[i].OnInvoke(arguments, this);
        }
    }
}
