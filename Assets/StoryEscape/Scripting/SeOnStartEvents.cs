using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeOnStartEvents : MonoBehaviour
{
    public List<SeActionBase> startActions;

    void Start ()
    {
        for (int i=0; i<startActions.Count; i++)
        {
            startActions[i].TriggerAction();
        }
    }
}
