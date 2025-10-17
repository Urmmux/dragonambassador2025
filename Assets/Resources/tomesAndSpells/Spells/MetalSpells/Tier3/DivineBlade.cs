using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineBlade : Spell
{
    public DivineBlade(){
        spellName = "Divine Blade";
        description = "Summon a blade from the heavens and smite your enemies. The divine blade subsumes a bit of your free will, forcing you to cast this spell again.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //big metal damage, inflicts trance on caster, forcing them to use divine blade again next turn
}
