using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : Spell
{
    public Blade(){
        spellName = "Blade";
        description = "Summon a metal blade and attack an enemy with it. Relies more on strength of body than of mind.";
        cooldown = 0;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //metal damage, one of the few spells to use the player's power instead of will, and also uses the target's defense
}
