using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : Spell
{
    public LightningBolt(){
        spellName = "Lightning Bolt";
        description = "Summon a bolt of lightning from the heavens to smite whatever it hits.";
        cooldown = 5;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //big lightning damage, inflict overloaded for 2 turns, and blackout for 1 turn
}
