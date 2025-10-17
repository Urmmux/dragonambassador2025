using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTail : Spell
{
    public DragonTail(){
        spellName = "Dragon Tail";
        description = "";
        cooldown = 2;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //AOE damage
}
