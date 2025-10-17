using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehavior : MonoBehaviour
{
    //some of the earliest code I ever wrote, forgive the strangeness
    //misnomer, used as a base class for other scripts, has more to do with dragon randomization. You are probably looking for "DragonBrain"
    protected DragStats GetDragStats()
    {
        Transform currentNode = gameObject.transform;
        Component component = null;
        while (!component && currentNode)
        {
            component = currentNode.gameObject.GetComponent(typeof(DragStats));
            try
            {
                currentNode = currentNode.parent.transform;
            }
            catch
            {
                currentNode = null;
            }
        }
        return component as DragStats;
    }
}