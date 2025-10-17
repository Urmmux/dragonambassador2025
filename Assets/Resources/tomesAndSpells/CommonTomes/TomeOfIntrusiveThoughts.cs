using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfIntrusiveThoughts : Tome
{
    void Awake(){
        tomeName = "Tome of Intrusive Thoughts";
        description = "Full of bad ideas, but effective ones. They make a frightening amount of sense in the moment.";
        spells = new Spell[3]
        {
            new Shock(),
            new DarkSpire(),
            new KnifeBarrage()
        };
    }

}
