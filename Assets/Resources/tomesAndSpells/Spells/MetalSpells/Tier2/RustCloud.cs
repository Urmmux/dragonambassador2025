using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustCloud : Spell
{
    public RustCloud(){
        spellName = "Rust Cloud";
        description = "A dense cloud of rust violently swirls around your enemy, tearing at them like sandpaper.";
        cooldown = 1;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //inflicts poison and bleed, if the target has regeneration, remove it and inflict exhaustion, bypassing resistance
}
