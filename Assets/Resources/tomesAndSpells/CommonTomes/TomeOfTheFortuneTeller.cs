using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheFortuneTeller : Tome
{
    void Awake(){
        tomeName = "Tome of the Fortune Teller";
        description = "Draw a card, seal your fate. Read the lines, illuminate.";
        spells = new Spell[3]
        {
            new MindRead(),
            new Doubt(),
            new EntropySpiral()
        };
    }

}
