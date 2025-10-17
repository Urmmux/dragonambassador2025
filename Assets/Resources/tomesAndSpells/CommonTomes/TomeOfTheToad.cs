using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheToad : Tome
{
    void Awake(){
        tomeName = "Tome of the Toad";
        description = "The giant toads of the west wait buried in the sand, and can discharge enough electricity to stun a dragon if you step on them.";
        spells = new Spell[3]
        {
            new Pulse(),
            new Ionize(),
            new Blind()
        };
    }

}
