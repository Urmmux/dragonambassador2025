using System;
using UnityEngine.Events;

[Serializable]
public struct ButtonInfo
{
    public string label;
    public UnityAction onClick;
}
