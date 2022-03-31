using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface denoting something is a result, all results will delegate to interfaces which will then
//act on a subject of some kind
public class Result
{
    //Execute method that takes arguments
    public static void Execute(List<ResultArguments> arguments) { Debug.LogError("Default execute behaviour is undefined"); }
}
