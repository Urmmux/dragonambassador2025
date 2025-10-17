using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheWorm : Tome
{
    void Awake(){
        tomeName = "Tome of the Worm";
        description = "328 years for the finger-length squirming creature you sacrifice on a hook. 328 years, before it transforms deep below the surface, and emerges a horror.";
        spells = new Spell[3]
        {
            new UltraHeal(),
            new Fireball(),
            new Overload()
        };
    }

}
