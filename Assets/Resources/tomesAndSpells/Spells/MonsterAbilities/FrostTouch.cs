using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostTouch : Spell
{
    public FrostTouch(){
        spellName = "Frost Touch";
        description = "";
        cooldown = 0;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //slight frost damage
}