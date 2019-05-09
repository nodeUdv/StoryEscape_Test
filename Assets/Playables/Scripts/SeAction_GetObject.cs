using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeAction_GetObject : SeActionBase
{
    public SeObjectBase objectToGet;

    public override bool TriggerAction ()
    {
        if (CanTrigger())
        {
            SePlayerController.instance.GetObject(objectToGet);
            return true;
        }

        return false;
        
    }
}
