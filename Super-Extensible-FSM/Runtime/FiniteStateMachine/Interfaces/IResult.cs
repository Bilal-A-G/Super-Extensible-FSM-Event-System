using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface denoting something is a result, all results will delegate to interfaces which will then
//act on a subject of some kind
public interface IResult
{
    //Execute method that takes arguments
    public void Execute(List<ResultArguments> arguments);
}
