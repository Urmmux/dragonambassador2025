using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBolt : Spell
{
    public IceBolt(){
        spellName = "Ice Bolt";
        description = "Hurl a chunk of ice.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //frost damage
}
