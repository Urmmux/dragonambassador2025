using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfNihilism : Tome
{
    void Awake(){
        tomeName = "Tome of Nihilism";
        description = "One becomes only one.";
        spells = new Spell[3]
        {
            new Reflection(),
            new StillMind(),
            new Silence()
        };
    }

}
