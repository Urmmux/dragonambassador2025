using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeSwarm : Spell
{
    public BladeSwarm(){
        spellName = "Blade Swarm";
        description = "Summons dozens upon dozens of blades and hurls them at an enemy.";
        cooldown = 4;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }
    public override void Cast(GameObject caster, GameObject target) {}
    //big metal damage, uses the caster's power stat, uses target's defense, inflicts vulnerable on the caster
}
