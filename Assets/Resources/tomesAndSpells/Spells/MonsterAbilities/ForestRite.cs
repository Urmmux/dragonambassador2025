using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestRite : Spell
{
    public ForestRite(){
        spellName = "Forest Rite";
        description = "";
        cooldown = 0;
        affectedBySilence = false;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //nature damage to both target and caster, grants protected and thorn armor to caster
}