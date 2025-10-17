using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerdantPact : Spell
{
    public VerdantPact(){
        spellName = "Verdant pact";
        description = "Make a pact with ancient woodland fae, sacrificing all your health for a bit of hope.";
        cooldown = 5;
        canTargetSelf = true;
        canTargetAlly = false;
        canTargetEnemy = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //reduces health to one, gains regeneration for the rest of the battle, gains invulnerable for 1 turn
}
