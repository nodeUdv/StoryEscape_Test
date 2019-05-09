using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeObjectContainer : MonoBehaviour
{
    public SeSimpleObject simpleObject;

    void Awake ()
    {
        GameObject.Instantiate(simpleObject.prefab, transform.position, transform.rotation);
    }
}
