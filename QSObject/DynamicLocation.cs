using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLocation{
    public object TimeStamp;
    public float X;
    public float Y;

    public DynamicLocation(float x, float y, object timeStamp)
    {
        X = x;
        Y = y;
        TimeStamp = timeStamp;
    }
}
