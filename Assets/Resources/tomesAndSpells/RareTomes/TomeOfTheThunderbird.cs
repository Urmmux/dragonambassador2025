using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheThunderbird : Tome
{
    void Awake(){
        tomeName = "Tome of the Thunderbird";
        description = "The thunderbird used to be a consort to the last dragon queen. When he remembers her, lightning sears the foothills and splits the rocks.";
        spells = new Spell[3]
        {
            new LightningBolt(),
            new Overload(),
            new FlameSword()
        };
    }

}
