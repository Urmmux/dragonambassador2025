using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheInitiate : Tome
{
    void Awake(){
        tomeName = "Tome of the Initiate";
        description = "They teach that every spell is a breath held just long enough. The pronounciation and the gestures, those are guidelines, but the breathing? That's a rule.";
        spells = new Spell[3]
        {
            new CreepingShadow(),
            new Blade(),
            new AshFall()
        };
    }

}
