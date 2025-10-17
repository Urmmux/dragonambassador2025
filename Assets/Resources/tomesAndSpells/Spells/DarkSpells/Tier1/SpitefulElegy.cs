using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitefulElegy : Spell
{
    public SpitefulElegy(){
        spellName = "Spiteful Elegy";
        description = "Chant a brief incantation that haunts your enemy for 4 turns.";
        cooldown = 3;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //applies haunted for 4 turns
}
