using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragStatInitial : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DragStats currentDrag = gameObject.GetComponent(typeof(DragStats)) as DragStats;

        int randomIndex = Random.Range(10, 16);

        currentDrag.power = randomIndex;

        randomIndex = Random.Range(1, 6);

        currentDrag.moody = randomIndex == 1;

        randomIndex = Random.Range(1, 4);

        currentDrag.traveler = randomIndex == 1;

        randomIndex = Random.Range(1, 4);

        currentDrag.resurrectionist = randomIndex == 1;

        randomIndex = Random.Range(1, 6);

        currentDrag.reader = randomIndex == 1;

        randomIndex = Random.Range(1, 4);

        currentDrag.proactivity = randomIndex;

        randomIndex = Random.Range(1, 4);

        currentDrag.boredom = randomIndex;

        randomIndex = Random.Range(1, 4);

        currentDrag.confidence = randomIndex;

        randomIndex = Random.Range(1, 5);

        currentDrag.honor = randomIndex;

        randomIndex = Random.Range(1, 16);

        currentDrag.dreamer = randomIndex == 1;

        randomIndex = Random.Range(1, 11);

        currentDrag.shifter = randomIndex == 1;

        randomIndex = Random.Range(1, 11);

        currentDrag.intolerant = randomIndex == 1 && !currentDrag.ruler;

        randomIndex = Random.Range(1, 5);

        currentDrag.brutality = randomIndex;

        randomIndex = Random.Range(1, 4);

        currentDrag.vainity = randomIndex;

        randomIndex = Random.Range(1, 4);

        currentDrag.jealousy = randomIndex;

        randomIndex = Random.Range(1, 4);

        currentDrag.expansionist = randomIndex;

        randomIndex = Random.Range(1, 4);

        currentDrag.collector = randomIndex == 1;

        randomIndex = Random.Range(1, 6);

        currentDrag.sloth = randomIndex == 1;

        randomIndex = Random.Range(1, 5);

        currentDrag.romantic = randomIndex == 1;

        randomIndex = Random.Range(1, 5);

        currentDrag.ruler = randomIndex == 1;

        randomIndex = Random.Range(1, 4);

        currentDrag.social = randomIndex;

        randomIndex = Random.Range(1, 5);

        currentDrag.hornColor = randomIndex;

        randomIndex = Random.Range(1, 4);

        currentDrag.hairColor = randomIndex;

        randomIndex = Random.Range(1, 4);

        currentDrag.skinColor = randomIndex;

        randomIndex = Random.Range(1, 7);

        currentDrag.scaleColor = randomIndex;

        randomIndex = Random.Range(1, 7);

        currentDrag.eyeColor = randomIndex;

        randomIndex = Random.Range(1, 6);

        switch (randomIndex)
        {
            case (1):
                currentDrag.favTreasure = "Amulet";
                break;
            case (2):
                currentDrag.favTreasure = "Chest";
                break;
            case (3):
                currentDrag.favTreasure = "Silk";
                break;
            case (4):
                currentDrag.favTreasure = "Mosaic";
                break;
            case (5):
                currentDrag.favTreasure = "Crown";
                break;
            default:
                currentDrag.favTreasure = "Error";
                break;
        }
        randomIndex = Random.Range(1, 6);

        switch (randomIndex)
        {
            case (1):
                currentDrag.favColor = "Blue";
                break;
            case (2):
                currentDrag.favColor = "Green";
                break;
            case (3):
                currentDrag.favColor = "Gold";
                break;
            case (4):
                currentDrag.favColor = "Red";
                break;
            case (5):
                currentDrag.favColor = "White";
                break;
            default:
                currentDrag.favColor = "Error";
                break;
        }

        currentDrag.wealth = 0;

        randomIndex = Random.Range(2, 5);

        currentDrag.playerAffection = randomIndex * 10;

        string name1;
        string name2;
        string name3;

        string[] n1Array;

        n1Array = new string[] { "Jade", "Xoriah", "Ash", "Quetzoca", "Wyrin", "Ragnar", "Tiamat", "Erza", "Thurinne", "Unn", "Isa", "Ivelle", "Ochre", "Platinum", "Serah", "Sook", "Sintir", "Dratha", "Diane", "Fulmina", "Ghaas", "Jezel", "Katherine", "Zirconia", "Zaaz", "Victoria", "Valencia", "Vivium", "Bellow", "Blast", "Nix", "Cass", "Nurumet", "Marrow", "Fafnir", "Iormungand", "Ladon", "Nidhug", "Ophiur", "Melusine", "Nithe", "Caoranach", "Muirdris", "Titanium", "Cobalt", "Iron", "Chrome", "Magnesia", "Euryale", "Vanadium", "Ascra", "Corona", "Bahamut", "Nagira", "Sethel", "Typha", "Zotzi", "Orochim", "Rexia", "Astrid", "Thriin", "Zirra", "Yshtar", "Azhun", "Auraline", "Osmara", "Tannix", "Niova", "Irune", "Indizar", "Chrysid" };

        randomIndex = Random.Range(0, n1Array.Length);

        name1 = n1Array[randomIndex];

        string[,] n2Array;

        n2Array = new string[,] {{
            //object-object pairings
            "Thorn", "Myre", "Crest", "Knife", "Jasper", "Amber", "Quartz", "Wind", "Earth", "Ever", "Thunder", "Frost", "Dream", "Moon", "Flame", "Soul", "Void", "Still", "Rune", "Gem", "Light", "Snow", "Fae", "Hammer", "Shelter", "Flesh", "Spark", "Ember", "Bone", "Star"
        },{
            //syllable-object pairings
            "Syl-", "Vol-", "Itter-", "Wyrm-", "Ris-", "Aar-", "Gaeh-", "Ghavel-", "Ilik-", "Hel-", "Loe-", "Zil-", "Xyr-", "Baala-", "Min-", "Sodo-", "Zhera-", "Cel-", "Yig-", "Dis-", "Kros-", "La-", "Ieschl-", "Tuiht-", "Rel-", "Nym-", "Crav-", "Bryn-", "Zin-", "Mos-"
        },{
            //syllable-syllable pairings
            "Solov", "Oronth", "Kevrar", "Laoxun", "Iach", "Nilmorr", "Absol", "Esther", "Teleran", "Yassur", "Unomis", "Umorad", "Indign", "Proser", "Giat", "Asvelish", "Auvelis", "Griseouv", "Hammirg", "Jagrif", "Juukal", "Cenag", "Cenif", "Krosen", "Melif", "Laevvil", "Zenebrid", "Chamel", "Mutan", "Bhelath"
        } };

        randomIndex = Random.Range(0, 3);

        int randomerIndex = Random.Range(0, 30);

        name2 = n2Array[randomIndex, randomerIndex];

        string[,] n3Array;

        n3Array = new string[,] {{
            //object-object pairings
            "witch", "thrasher", "screamer", "song", "keeper", "bearer", "myth", "claw", "fang", "scorcher", "terror", "sorrow", "fury", "wing", "tail", "horn", "shaker", "serpent", "seeker", "bird", "eater", "shrine", "bloom", "pact"
        },{
            //syllable-object pairings
            "Storm", "Ore", "Aurora", "Fall", "Meteor", "Havoc", "Wight", "Heaven", "Hell", "Moss", "Ascension", "Joy", "Moth", "Ruin", "Plate", "Pine", "Forge", "Scale", "Scar", "Stone", "Nemesis", "Prism", "Spiral", "Vault"
        },{
            //syllable-syllable pairings
            "endon", "edith", "error", "urium", "ision", "oth", "otiarn", "olete", "adate", "y", "ia", "aria", "onic", "arrum", "escent", "ich", "elle", "inne", "avid", "iary", "avix", "yrak", "avora", "athex"
        } };

        randomerIndex = Random.Range(0, 20);

        name3 = n3Array[randomIndex, randomerIndex];

        currentDrag.dragName = name1 + " " + name2 + name3;

        if (name2 == "Earth")
        {
            currentDrag.affinity = "nature";
        }
        else if (name2 == "Frost" || name2 == "Snow")
        {
            currentDrag.affinity = "ice";
        }
        else if (name2 == "Night" || name2 == "Void")
        {
            currentDrag.affinity = "void";
        }
        else if (name2 == "Thunder" || name2 == "Spark")
        {
            currentDrag.affinity = "lightning";
        }
        else if (name2 == "Flame" || name2 == "Ember")
        {
            currentDrag.affinity = "fire";
        }
        else if (name3 == "Moss" || name3 == "Stone")
        {
            currentDrag.affinity = "nature";
        }
        else if (name3 == "scorcher")
        {
            currentDrag.affinity = "fire";
        }
        else if (name3 == "Aurora")
        {
            currentDrag.affinity = "ice";
        }
        else if (name3 == "Nemesis")
        {
            currentDrag.affinity = "void";
        }
        else if (name3 == "Havoc")
        {
            currentDrag.affinity = "lightning";
        }
        else
        {
            randomIndex = Random.Range(1, 7);
            switch (randomIndex)
            {
                case (1):
                    currentDrag.affinity = "fire";
                    break;
                case (2):
                    currentDrag.affinity = "fire";
                    break;
                case (3):
                    currentDrag.affinity = "ice";
                    break;
                case (4):
                    currentDrag.affinity = "lightning";
                    break;
                case (5):
                    currentDrag.affinity = "void";
                    break;
                case (6):
                    currentDrag.affinity = "nature";
                    break;
            }
        }

        currentDrag.abilities = new List<Spell>();
        currentDrag.abilities.Add(new DragonClaw());
        currentDrag.abilities.Add(new DragonTail());
        currentDrag.abilities.Add(new DragonBreath());

        List<Spell> supportPool = new List<Spell>()
        {
            new Blind(),
            new Purify(),
            new Shiver(),
            new Curse(),
            new AshFall(),
            new Disrupt(),
            new GreaterHeal(),
            new Reflection()
        };

        int index = Random.Range(0, supportPool.Count);
        currentDrag.abilities.Add(supportPool[index]);
        supportPool.RemoveAt(index);
        index = Random.Range(0, supportPool.Count);
        currentDrag.abilities.Add(supportPool[index]);
    }
}


