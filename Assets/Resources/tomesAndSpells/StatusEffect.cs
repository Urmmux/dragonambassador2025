using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StatusEffect
{
    public string type;
    public int magnitude;
    public int duration;

    public StatusEffect(string type, int magnitude, int duration)
    {
        this.type = type;
        this.magnitude = magnitude;
        this.duration = duration;
    }
}