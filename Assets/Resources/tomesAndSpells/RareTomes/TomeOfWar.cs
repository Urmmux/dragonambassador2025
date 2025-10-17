using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfWar : Tome
{
    void Awake(){
        tomeName = "Tome of War";
        description = "The great blessing of the dragons is that nobody can afford war anymore.";
        spells = new Spell[3]
        {
            new Fireball(),
            new Detonate(),
            new RustCloud()
        };
    }

}
