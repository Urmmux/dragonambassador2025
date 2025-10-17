using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalScreen : Spell
{
    public MetalScreen(){
        spellName = "Metal Screen";
        description = "Creates a barrier of metal mesh that absorbs incoming damage.";
        cooldown = 1;
        canTargetSelf = true;
        canTargetAlly = true;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //grants the target protected
}
