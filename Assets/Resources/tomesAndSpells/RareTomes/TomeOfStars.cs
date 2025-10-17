using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfStars : Tome
{
    void Awake(){
        tomeName = "Tome of Stars";
        description = "The bodies of heaven moved in accordance to pattern. It was a dance she was beginning to learn.";
        spells = new Spell[3]
        {
            new Meteor(),
            new Collapse(),
            new GreaterHeal()
        };
    }

}
