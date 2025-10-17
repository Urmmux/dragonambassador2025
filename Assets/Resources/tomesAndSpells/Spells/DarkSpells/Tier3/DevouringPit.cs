using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevouringPit : Spell
{
    public DevouringPit(){
        spellName = "Devouring Pit";
        description = "Opens a pit to the underworld, so the souls of the desparate can feed on your enemy. Sacrifices your vision for a while.";
        cooldown = 2;canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //big dark damage, inflicts cursed, inflicts blind on player
}
