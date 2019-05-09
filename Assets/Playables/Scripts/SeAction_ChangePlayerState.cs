using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeAction_ChangePlayerState : SeActionBase
{
    public bool canMove;
    public bool canLook;

    public override bool TriggerAction ()
    {
        if (CanTrigger())
        {
            SePlayerController.instance.ChangeControllerState(canMove, canLook);
            return true;
        }

        return false;
    }
}
