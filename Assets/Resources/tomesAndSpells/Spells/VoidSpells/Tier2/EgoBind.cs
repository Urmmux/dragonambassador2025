using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgoBind : Spell
{
    public EgoBind(){
        spellName = "Ego-bind";
        description = "Causes the target's identity to fuse with all current status effects, prevent them from being removed.";
        cooldown = 2;
        canTargetSelf = true;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //status effects are permanant and can't be removed
}
