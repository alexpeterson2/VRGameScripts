using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookedState : State
{
    public HookedState(StateController stateController) : base(stateController) { }

    public override void CheckTransition()
    {
        throw new System.NotImplementedException();
    }

    public override void Act()
    {
        //if ()
    }
}
