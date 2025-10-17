using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheWraith : Tome
{
    void Awake(){
        tomeName = "Tome of the Wraith";
        description = "Icy fingers trace from your neck down your back, and forgotten Numian words echo in your mind.";
        spells = new Spell[3]
        {
            new SpitefulElegy(),
            new SoulJudgement(),
            new Shiver()
        };
    }

}
