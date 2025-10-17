using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonClaw : Spell
{
    public DragonClaw(){
        spellName = "Dragon Claw";
        description = "";
        cooldown = 0;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //big damage
}
