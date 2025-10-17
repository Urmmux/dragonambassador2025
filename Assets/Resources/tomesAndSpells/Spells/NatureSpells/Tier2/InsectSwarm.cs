using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectSwarm : Spell
{
    public InsectSwarm(){
        spellName = "Insect Swarm";
        description = "Summon a swarm of wasps to poison and debilitate your enemies.";
        cooldown = 2;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //nature damage, inflicts poison and vulnerable
}
