using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheDullahan : Tome
{
    void Awake(){
        tomeName = "Tome of the Dullahan";
        description = "It was said that Cloh, the lover of Tatyin, was found guilty of murder and hung from his neck. Tatyin in his grief, slew the entire town, and was eventually beheaded by the knights.";
        spells = new Spell[3]
        {
            new Fireball(),
            new FlameSword(),
            new HauntingLament()
        };
    }

}
