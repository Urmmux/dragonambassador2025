using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBlade : Spell
{
    public LongBlade(){
        spellName = "Longblade";
        description = "Summon a large metal blade, heavy enough to crack stone. Relies on the strength of the caster's body, not mind.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //metal damage, one of the few spells to use the player's power instead of will, and also uses the target's defense
}
