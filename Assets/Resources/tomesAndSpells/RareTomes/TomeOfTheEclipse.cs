using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheEclipse : Tome
{
    void Awake(){
        tomeName = "Tome of the Eclipse";
        description = "A mere 7 minutes so powerful, it's been recorded on the walls of Nume for over 100 years.";
        spells = new Spell[3]
        {
            new DarkSpire(),
            new EgoBind(),
            new BlackHole()
        };
    }

}
