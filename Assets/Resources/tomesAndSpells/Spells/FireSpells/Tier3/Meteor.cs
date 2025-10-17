using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Spell
{
    public Meteor(){
        spellName = "Meteor";
        description = "Call down a ball of fire from the heavens. Does massive damage, but leaves you drained.";
        cooldown = 3;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //high damage fire spell, inflicts exhausted and blind on player
}
