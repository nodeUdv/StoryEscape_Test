using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SeTrigger : MonoBehaviour
{
    public SeActionBase action;

    public bool triggerOnce = true;

    private bool triggered;

    void OnTriggerEnter (Collider other)
    {
        if (!triggered)
        {
            if (action != null)
            {
                if (action.TriggerAction())
                {
                    if (triggerOnce) triggered = true;
                }                    
            }
        }
    }
}
