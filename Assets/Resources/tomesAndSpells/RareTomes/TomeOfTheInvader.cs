using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheInvader : Tome
{
    void Awake(){
        tomeName = "Tome of the Invader";
        description = "My mind couldn't bear it, refused to grasp it. How could something beautiful be so wrong? How could the sky peel back and reveal new wonders?";
        spells = new Spell[3]
        {
            new Vestige(),
            new ReachFromBeyond(),
            new Purify()
        };
    }

}
