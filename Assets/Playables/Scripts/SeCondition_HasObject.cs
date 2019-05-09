using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeCondition_HasObject : SeConditionBase
{
    public List<SeSimpleObject> objectsToHave;

    public override bool CheckCondition ()
    {
        bool b = HasAllNeeded();
        return b;
    }

    public bool HasAllNeeded()
    {
        bool b = true;
        for (int i=0; i<objectsToHave.Count; i++)
        {
            b &= PlayerPrefs.GetInt(objectsToHave[i].keyName, 0) > 0;
        }

        return b;
    }
}
