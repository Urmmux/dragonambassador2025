using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellStats : MonoBehaviour
{

    public enum Terrain
    {
        Deep,
        Field,
        Mountain,
        Forest,
        Shroom
    }
    public Terrain type;
    // 0-deep 1-field 2-mountain 3-forest 4-shroom

    public enum OverworldStructure
    {
        None,
        Town,
        City,
        Cave,
        Ruins,
        Shipwreck,
        Lair
    }
    public OverworldStructure has;
    // 1-town 2-city 3-cave 4-ruins 5-shipwreck 6-lair

    public GameObject homeTo;

    public GameObject ownedBy;

    public bool tempExpansionPoint = false;

    public bool isExpansionPoint(){
        if (has == OverworldStructure.Lair || tempExpansionPoint){
            return true;
        } else {
            return false;
        }
    }
}
