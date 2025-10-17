using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheLeech : Tome
{

    void Awake(){
        tomeName = "Tome of the Leech";
        description = "The best kind of job is one someone else already did for you.";
        spells = new Spell[3]
        {
            new Overload(),
            new DrainPower(),
            new EldritchGrasp()
        };
    }

}
