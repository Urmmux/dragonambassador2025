using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheHag : Tome
{
    void Awake(){
        tomeName = "Tome of the Hag";
        description = "Take in all the little joys of life in the swamps; the taste boiled fish eyes, the smell of scarlet moss, the lights of fireflies at night.";
        spells = new Spell[3]
        {
            new Curse(),
            new EgoBind(),
            new WeedGrowth()
        };
    }

}
