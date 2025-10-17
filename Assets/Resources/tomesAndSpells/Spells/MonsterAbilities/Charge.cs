using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Spell
{
    public Charge(){
        spellName = "Charge";
        description = "";
        cooldown = 0;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //big no-affinity damage
}
