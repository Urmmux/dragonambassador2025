using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoothingVoice : Spell
{
    public SoothingVoice(){
        spellName = "Soothing Voice";
        description = "Brings back a memory of a voice you used to know.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = true;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //base - give "comfort" status effect to caster
    //if has caster has status "desire", override and heal target
    //if has caster has status "bitterness", override, and apply hail and vulnerable to target
}
