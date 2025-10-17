using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfForgottenMemories : Tome
{
    void Awake(){
        tomeName = "Tome of Forgotten Memories";
        description = "It fades as quickly as it comes: a child's last hug before leaving, a shared hot cider between friends on a cold day, a sarcastic joke you're certain wasn't a joke, two voices yelling when you were supposed to be asleep.";
        spells = new Spell[3]
        {
            new ChildhoodWish(),
            new SoothingVoice(),
            new BuriedRegret()
        };
    }

}
