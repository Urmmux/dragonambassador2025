using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OathOfDeliverance : Spell
{
    public OathOfDeliverance(){
        spellName = "Oath of Deliverance";
        description = "";
        cooldown = 4;
    }

    public override void Cast(GameObject caster, GameObject target) {}
    //huge boost to tempPower of all enemies in battle, inflicts sealed on player
}
