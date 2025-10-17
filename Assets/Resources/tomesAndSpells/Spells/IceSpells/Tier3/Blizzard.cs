using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : Spell
{
    public Blizzard(){
        spellName = "Blizzard";
        description = "Call forth a maelstrom of ice to bury your enemies.";
        cooldown = 3;
        canTargetSelf = false;
        canTargetAlly = false;
        canTargetEnemy = true;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //ice damage, inflicts blind for 3 turns and exposed
}
