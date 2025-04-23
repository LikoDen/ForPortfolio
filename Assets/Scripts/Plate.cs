using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public LinePart linePart;
    public bool isBroken;

    public void SetValues(bool isBroke, LinePart newLinePart, Material newMaterial)
    {
        linePart = newLinePart;
        isBroken = isBroke;
        GetComponent<Renderer>().material = newMaterial;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(isBroken)
            Destroy(gameObject);
    }
}
