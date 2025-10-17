using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheShinobi : Tome
{
    void Awake(){
        tomeName = "Tome of the Shinobi";
        description = "He seemed kind. I didn't know it at the time, but his knife had the blood of the king on it. We shared a meal of stew and cheese, and then he left for his homeland.";
        spells = new Spell[3]
        {
            new KnifeBarrage(),
            new Focus(),
            new BladeSwarm()
        };
    }

}
