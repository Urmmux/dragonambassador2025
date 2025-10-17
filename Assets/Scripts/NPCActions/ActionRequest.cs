using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRequest
{
    public string actionType;        // e.g. "attack"
    public GameObject actor;         // the NPC taking the action
    public GameObject moveTargetSprite;        // where the action is aimed
    public string targetType;        // e.g. "dragon", "city", "ruins"
    public GameObject targetController; //gameobject where we can find the stats for the target

    public ActionRequest(
        string actionType, 
        GameObject moveTargetSprite, 
        GameObject targetController, 
        string targetType, 
        GameObject actor)
    {
        this.actionType = actionType;
        this.actor = actor;
        this.moveTargetSprite = moveTargetSprite;
        this.targetType = targetType;
        this.targetController = targetController;
    }
}