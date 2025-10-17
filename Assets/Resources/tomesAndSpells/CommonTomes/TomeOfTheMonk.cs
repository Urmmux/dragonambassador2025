using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheMonk : Tome
{
    void Awake(){
        tomeName = "Tome of the Monk";
        description = "The five tenents that led the Vill to break away from the academy: strike without malice, think without worry, learn without masters, give without strings, pray without gods.";
        spells = new Spell[3]
        {
            new Focus(),
            new Heal(),
            new MindRead()
        };
    }

}
