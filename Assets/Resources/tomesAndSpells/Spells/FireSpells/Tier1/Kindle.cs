using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kindle : Spell
{
    public Kindle(){
        spellName = "Kindle";
        description = "A warmth inside keeps one going, healing injuries. The more effects the target has, the greater the respite.";
        cooldown = 1;
        canTargetSelf = true;
        canTargetAlly = true;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //healing that scales with number of status effects
}
