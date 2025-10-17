using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : Spell
{
    public Phase(){
        spellName = "Phase";
        description = "";
        cooldown = 3;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //damage target and gain invulnerability for 1 turn
}
