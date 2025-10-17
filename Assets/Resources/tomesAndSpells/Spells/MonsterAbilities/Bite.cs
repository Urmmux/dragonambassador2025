using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : Spell
{
    public Bite(){
        spellName = "Bite";
        description = "";
        cooldown = 0;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //moderate no-affinity damage, inflicts exposed
}
