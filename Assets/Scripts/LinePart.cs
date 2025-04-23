using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LinePart : MonoBehaviour
{
    public Plate[] plates;
    public Material[] materials;
    public bool isCloseNow;
    public float notBroken;

    public void OpenPlates(bool isClose)
    {
        isCloseNow = isClose;
        
        var matBroken = isClose ? materials[0] : materials[1];
        var matNotBroken = isClose ? materials[0] : materials[2];
            
        if (Random.value <= 0.5f)
        {
            plates[0].SetValues(false, this, matNotBroken);
            plates[1].SetValues(true, this, matBroken);
            notBroken = -2.5f;
        }
        else
        {
            plates[0].SetValues(true, this, matBroken);
            plates[1].SetValues(false, this, matNotBroken);
            notBroken = 2.5f;
        }
    }
}
