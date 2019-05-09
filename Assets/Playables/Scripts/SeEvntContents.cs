using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SeActionBase : ScriptableObject {

    public List<SeConditionBase> conditions;
    public SeActionBase elseAction;

    public abstract bool TriggerAction ();
    
    public bool CanTrigger()
    {
        bool b = true;
        for (int i=0; i<conditions.Count; i++)
        {
            b &= conditions[i].CheckCondition();
        }

        if (!b && elseAction != null)
        {
            elseAction.TriggerAction();
            Debug.Log("SeAction[" + this.name + "] triggered");
        }

        return b;
    }
}

public abstract class SeConditionBase : ScriptableObject {

    public abstract bool CheckCondition ();
}

public enum SeObjectType {Permanent=0, Combinable=1, Sequence=2, World=3}

public abstract class SeObjectBase : ScriptableObject {

    public GameObject prefab;
    public string keyName = "Object";
    public SeObjectType objectType = 0;
}