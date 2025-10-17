using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfRadiance : Tome
{
    void Awake(){
        tomeName = "Tome of Radiance";
        description = "Through the storm, I saw a single sunbeam, a gap in the clouds, only lasting a moment.";
        spells = new Spell[3]
        {
            new Blind(),
            new Purify(),
            new Overload()
        };
    }

}
