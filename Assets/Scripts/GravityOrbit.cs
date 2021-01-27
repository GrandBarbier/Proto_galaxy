using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbit : MonoBehaviour
{
    public float gravity;

    public bool fixedDirection;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GravityCtrl>())
        {
            other.GetComponent<GravityCtrl>().gravity = this.GetComponent<GravityOrbit>();
        }
    }
}
