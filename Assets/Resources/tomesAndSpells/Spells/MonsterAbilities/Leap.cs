using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leap : Spell
{
    public Leap(){
        spellName = "Leap";
        description = "";
        cooldown = 0;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //moderate no-affinity damage
}
