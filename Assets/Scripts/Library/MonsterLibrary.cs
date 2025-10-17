using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLibrary : MonoBehaviour
{
    static string[] tier1Ice = new string[] {"fae"};
    static string[] tier2Ice = new string[] {"frost elemental"};
    static string[] tier3Ice = new string[] {"mammoth", "ice worm"};

    static string[] tier1Dark = new string[] {"skeleton"};
    static string[] tier2Dark = new string[] {"wraith", "zombie"};
    static string[] tier3Dark = new string[] {"dullahan"};

    static string[] tier1Fire = new string[] {"firefly"};
    static string[] tier2Fire = new string[] {"fire elemental"};
    static string[] tier3Fire = new string[] {"pheonix"};

    static string[] tier1Lightning = new string[] {"wisp"};
    static string[] tier2Lightning = new string[] {"olm", "kobold"};
    static string[] tier3Lightning = new string[] {"thunderbird"};

    static string[] tier1Metal = new string[] {"dancing sword"};
    static string[] tier2Metal = new string[] {"numian armor", "sunken hero"};
    static string[] tier3Metal = new string[] {"golem"};

    static string[] tier1Nature = new string[] {"dryad"};
    static string[] tier2Nature = new string[] {"maneater", "myconid"};
    static string[] tier3Nature = new string[] {"sand worm"};

    static string[] tier1Void = new string[] {"goblin"};
    static string[] tier2Void = new string[] {"formless beast"};
    static string[] tier3Void = new string[] {"invader"};

    static GameObject GetFromResources(string monsterToGet) {
        return Resources.Load<GameObject>("monsters/"+monsterToGet);
    }

    public static GameObject GetDragonMinion(string affinity, int wealth) {
        string minionToGet = "";

        if (affinity == "ice")
        {
            if (wealth < 10)
                minionToGet = tier1Ice[Random.Range(0, tier1Ice.Length)];
            else if (wealth < 20)
                minionToGet = tier2Ice[Random.Range(0, tier2Ice.Length)];
            else
                minionToGet = tier3Ice[Random.Range(0, tier3Ice.Length)];
        }
        else if (affinity == "fire")
        {
            if (wealth < 10)
                minionToGet = tier1Fire[Random.Range(0, tier1Fire.Length)];
            else if (wealth < 20)
                minionToGet = tier2Fire[Random.Range(0, tier2Fire.Length)];
            else
                minionToGet = tier3Fire[Random.Range(0, tier3Fire.Length)];
        }
        else if (affinity == "lightning")
        {
            if (wealth < 10)
                minionToGet = tier1Lightning[Random.Range(0, tier1Lightning.Length)];
            else if (wealth < 20)
                minionToGet = tier2Lightning[Random.Range(0, tier2Lightning.Length)];
            else
                minionToGet = tier3Lightning[Random.Range(0, tier3Lightning.Length)];
        }
        else if (affinity == "void")
        {
            if (wealth < 10)
                minionToGet = tier1Void[Random.Range(0, tier1Void.Length)];
            else if (wealth < 20)
                minionToGet = tier2Void[Random.Range(0, tier2Void.Length)];
            else
                minionToGet = tier3Void[Random.Range(0, tier3Void.Length)];
        }
        else if (affinity == "nature")
        {
            if (wealth < 10)
                minionToGet = tier1Nature[Random.Range(0, tier1Nature.Length)];
            else if (wealth < 20)
                minionToGet = tier2Nature[Random.Range(0, tier2Nature.Length)];
            else
                minionToGet = tier3Nature[Random.Range(0, tier3Nature.Length)];
        }
        else if (affinity == "dark")
        {
            if (wealth < 10)
                minionToGet = tier1Dark[Random.Range(0, tier1Dark.Length)];
            else if (wealth < 20)
                minionToGet = tier2Dark[Random.Range(0, tier2Dark.Length)];
            else
                minionToGet = tier3Dark[Random.Range(0, tier3Dark.Length)];
        }

        return GetFromResources(minionToGet);
    }

    public static void AssignAbilities(Monster monster){
        switch (monster.monName){
            case "fae":
                monster.abilities.Add(new Heal());
                monster.abilities.Add(new FrostWind());
                monster.abilities.Add(new IceSpike());
                monster.abilities.Add(new FrostTouch());
                break;
            case "frost elemental":
                monster.abilities.Add(new IceSpike());
                monster.abilities.Add(new IcicleBarrage());
                monster.abilities.Add(new Slush());
                break;
            case "mammoth":
                monster.abilities.Add(new IceSpike());
                monster.abilities.Add(new Charge());
                break;
            case "ice worm":
                monster.abilities.Add(new LightningBolt());
                monster.abilities.Add(new Charge());
                monster.abilities.Add(new InsectSwarm());
                break;
            case "skeleton":
                monster.abilities.Add(new Blade());
                monster.abilities.Add(new CreepingShadow());
                monster.abilities.Add(new FlameBurst());
                monster.abilities.Add(new Leap());
                break;
            case "zombie":
                monster.abilities.Add(new Bite());
                monster.abilities.Add(new CreepingShadow());
                monster.abilities.Add(new KnitFlesh());
                break;
            case "wraith":
                monster.abilities.Add(new HauntingLament());
                monster.abilities.Add(new Blind());
                monster.abilities.Add(new FrostTouch());
                monster.abilities.Add(new EgoBind());
                monster.abilities.Add(new DrainPower());
                break;
            case "dullahan":
                monster.abilities.Add(new Despair());
                monster.abilities.Add(new SoulJudgement());
                monster.abilities.Add(new LongBlade());
                monster.abilities.Add(new OathOfDeliverance());
                monster.abilities.Add(new FlameSword());
                monster.abilities.Add(new Strike());
                break;
            case "firefly":
                monster.abilities.Add(new Fireball());
                monster.abilities.Add(new Wait());
                break;
            case "fire elemental":
                monster.abilities.Add(new Fireball());
                monster.abilities.Add(new FlamingBarrage());
                break;
            case "pheonix":
                monster.abilities.Add(new UltraHeal());
                monster.abilities.Add(new FlamingBarrage());
                monster.abilities.Add(new Fireball());
                break;
            case "wisp":
                monster.abilities.Add(new Shock());
                monster.abilities.Add(new Disrupt());
                monster.abilities.Add(new Phase());
                monster.abilities.Add(new Wait());
                break;
            case "olm":
                monster.abilities.Add(new Shock());
                monster.abilities.Add(new Overload());
                monster.abilities.Add(new Charge());
                break;
            case "kobold":
                monster.abilities.Add(new Leap());
                monster.abilities.Add(new Ionize());
                monster.abilities.Add(new Dampener());
                break;
            case "thunderbird":
                monster.abilities.Add(new Charge());
                monster.abilities.Add(new LightningBolt());
                monster.abilities.Add(new HauntingLament());
                monster.abilities.Add(new Storm());
                break;
            case "dancing sword":
                monster.abilities.Add(new Blade());
                monster.abilities.Add(new Strike());
                break;
            case "numian armor":
                monster.abilities.Add(new Charge());
                monster.abilities.Add(new LongBlade());
                break;
            case "sunken hero":
                monster.abilities.Add(new Strike());
                monster.abilities.Add(new Blade());
                monster.abilities.Add(new Heal());
                monster.abilities.Add(new DarkSpire());
                monster.abilities.Add(new MetalScreen());
                break;
            case "golem":
                monster.abilities.Add(new Strike());
                monster.abilities.Add(new Charge());
                monster.abilities.Add(new LavaSurge());
                break;
            case "dryad":
                monster.abilities.Add(new ThornShot());
                monster.abilities.Add(new InsectSwarm());
                monster.abilities.Add(new Roots());
                monster.abilities.Add(new StillMind());
                monster.abilities.Add(new ForestRite());
                break;
            case "myconid":
                monster.abilities.Add(new Strike());
                monster.abilities.Add(new GreaterHeal());
                monster.abilities.Add(new Roots());
                monster.abilities.Add(new FungalSpores());
                break;
            case "maneater":
                monster.abilities.Add(new Bite());
                monster.abilities.Add(new Roots());
                monster.abilities.Add(new Focus());
                break;
            case "sand worm":
                monster.abilities.Add(new Charge());
                monster.abilities.Add(new Bite());
                monster.abilities.Add(new InsectSwarm());
                monster.abilities.Add(new Collapse());
                break;
            case "goblin":
                monster.abilities.Add(new Bite());
                monster.abilities.Add(new KnifeBarrage());
                monster.abilities.Add(new Vestige());
                break;
            case "formless beast":
                monster.abilities.Add(new Bite());
                monster.abilities.Add(new GreaterHeal());
                monster.abilities.Add(new Phase());
                monster.abilities.Add(new Overload());
                monster.abilities.Add(new Shiver());
                break;
            case "invader":
                monster.abilities.Add(new Bite());
                monster.abilities.Add(new ReachFromBeyond());
                monster.abilities.Add(new Vestige());
                break;
            
        }
    }
}
