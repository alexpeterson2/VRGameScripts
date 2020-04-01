using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtState : State
{
    public CaughtState(StateController stateController) : base(stateController) { }

    public override void CheckTransition()
    {
        throw new System.NotImplementedException();
    }

    public override void Act()
    {
        throw new System.NotImplementedException();
    }
}
