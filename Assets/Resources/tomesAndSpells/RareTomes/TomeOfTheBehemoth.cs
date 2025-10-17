using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheBehemoth : Tome
{
    void Awake(){
        tomeName = "Tome of Behemoth";
        description = "It towered over even the oldest trees of the forest, and the roar, a wall of wind so great that it lifted the ground in chunks.";
        spells = new Spell[3]
        {
            new Storm(),
            new Overload(),
            new DivineBlade()
        };
    }

}
