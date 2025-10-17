using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : Spell
{
    public Strike(){
        spellName = "Strike";
        description = "";
        cooldown = 0;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //big no-affinity damage, inflicts bleed
}
