using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase : ScriptableObject
{
    public abstract void Execute(GameObject callingObject);

    public virtual void Update()
    {
        return;
    }

    public virtual void FixedUpdate()
    {
        return;
    }
}
