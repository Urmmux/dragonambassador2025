using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntropySpiral : Spell
{
    public EntropySpiral(){
        spellName = "Entropy-Spiral";
        description = "Uses the innate entropy of the caster to deal void damage, and then increases the entropy of the caster";
        cooldown = 1;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }
    public override void Cast(GameObject caster, GameObject target) {}
    //deals void damage, gives caster entropy, which decreases defense but increases will, this spell scales off the magnitude of entropy on the caster
}
