using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBreath : Spell
{
    public DragonBreath(){
        spellName = "Dragon Breath";
        description = "";
        cooldown = 4;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //uses will, big AOE damage of whatever affinity the dragon is
}
