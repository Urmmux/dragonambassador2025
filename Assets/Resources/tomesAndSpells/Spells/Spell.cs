using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public bool affectedBySilence = true;
    public bool canTargetSelf = false;
    public bool canTargetAlly = false;
    public bool canTargetEnemy = false;
    //not all three can be true at once- not enough buttons for this and three enemies
    public string spellName;
    public string description;
    //total cooldown
    public int cooldown = 0;
    //current cooldown
    public int cooldownCounter = 0;

    public abstract void Cast(GameObject caster, GameObject target);

    public bool IsReady()
    {
        return cooldownCounter == 0;
    }

    public void ReduceCooldown()
    {
        if (cooldownCounter > 0)
            cooldownCounter--;
    }

    public void StartCooldown()
    {
        cooldownCounter = cooldown;
    }

    public bool IsWeakTo(string targetAffinity, string affinity){
        if (targetAffinity == "fire")
            return affinity == "ice" || affinity == "void";
        if (targetAffinity == "ice")
            return affinity == "fire" || affinity == "lightning";
        if (targetAffinity == "lightning")
            return affinity == "nature" || affinity == "void";
        if (targetAffinity == "nature")
            return affinity == "metal" || affinity == "ice";
        if (targetAffinity == "metal")
            return affinity == "dark";
        if (targetAffinity == "dark")
            return affinity == "lightning";

    return false;
    }

    public bool IsResistantTo(string targetAffinity, string affinity){
        if (targetAffinity == "fire")
            return affinity == "fire";
        if (targetAffinity == "ice")
            return affinity == "ice" || affinity == "void";
        if (targetAffinity == "lightning")
            return affinity == "lightning" || affinity == "metal";
        if (targetAffinity == "nature")
            return affinity == "nature" || affinity == "dark";
        if (targetAffinity == "metal")
            return affinity == "ice" || affinity == "metal" || affinity == "fire";
        if (targetAffinity == "dark")
            return affinity == "fire" || affinity == "dark";

    return false;
    }

    public void DamageTarget(int mult, GameObject caster, GameObject target, bool attackerphys, bool defenderphys, string affinity = ""){
        Debug.Log("starting damage target");
        //get stats
        BattleStats casterStats = caster.GetComponent<BattleStats>();
        BattleStats targetStats = target.GetComponent<BattleStats>();

        if (casterStats == null || targetStats == null)
        {
            Debug.LogWarning("missing stats on one of the fighters");
            return;
        }

        //worsen bleed if attacker physical
        if (attackerphys){
            int b = casterStats.statusEffects.FindIndex(status => status.type == "bleed");
            if (b >= 0)
            {
                StatusEffect bleed = casterStats.statusEffects[b];
                bleed.magnitude += 1;
                casterStats.statusEffects[b] = bleed;
            }
        }

        //get damage from attacker stat
        float damage;
        if (attackerphys){
            damage = casterStats.tempPower* mult;
            int q = casterStats.statusEffects.FindIndex(status => status.type == "heavy" || status.type == "exhausted");
            if (q >= 0)
            {
                damage = damage * 0.6f;
            }
        } else {
            damage = casterStats.will* mult;
            int q = casterStats.statusEffects.FindIndex(status => status.type == "exhausted");
            if (q >= 0)
            {
                damage = damage * 0.6f;
            }
        }

        //reduce by defender stat
        if (defenderphys){
            int h = targetStats.statusEffects.FindIndex(status => status.type == "heavy");
            if (h >= 0)
            {
                damage = damage * 0.6f;
            }
            int e = targetStats.statusEffects.FindIndex(status => status.type == "exposed");
            if (e >= 0)
            {
                damage = damage * 1.5f;
            }
           damage -= targetStats.defense;
        } else {
            damage -= targetStats.resistance;
        }

        //if ionized set all damage to lightning affinity
        int io = casterStats.statusEffects.FindIndex(status => status.type == "ionized");
        if (io >= 0)
        {
            affinity = "lightning";
        }

        //nothing happens if lightning is blackout
        if (affinity == "lightning"){
            int bl = casterStats.statusEffects.FindIndex(status => status.type == "blackout");
            if (bl >= 0)
            {
                Debug.Log("blackout set the damage to zero");
                return;
            }
        }

        //nothing happens if target is invulnerable
        int i = targetStats.statusEffects.FindIndex(status => status.type == "invulnerable");
        if (i >= 0)
        {
            Debug.Log("target is invulnerable");
            return;
        }

        int noI = casterStats.statusEffects.FindIndex(status => status.type == "blind");
        if (noI >= 0)
        {
            //nothing happens if blind miss
            if (attackerphys || casterStats.type == "player"){
                int rand = Random.Range(1, 5);
                    if (rand == 1){
                        Debug.Log("miss due to blindness");
                        return;
                    }
            }
        }

        //reduce damage if protected
        int p = targetStats.statusEffects.FindIndex(status => status.type == "protected");
        if (p >= 0)
        {
            StatusEffect protect = targetStats.statusEffects[p];
            damage -= protect.magnitude;
        }

        //apply weakness or resistance
        if (IsWeakTo(targetStats.affinity, affinity)){
            damage = damage * 1.5f;
        } else if (IsResistantTo(targetStats.affinity, affinity)){
            damage = damage * 0.6f;
        }

        //check if wet status effect does anything
        if (affinity == "lightning" || affinity == "ice"){
            int w = targetStats.statusEffects.FindIndex(status => status.type == "wet");
            if (w >= 0){
                damage = damage * 1.5f;
            }
        } else if (affinity == "fire"){
            int w =targetStats.statusEffects.FindIndex(status => status.type == "wet");
            if (w >= 0){
                damage = damage * 0.6f;
            }
        }

        //check if target takes extra damage from cursed
        if (affinity == "dark"){
            int c =targetStats.statusEffects.FindIndex(status => status.type == "cursed");
            if (c >= 0){
                StatusEffect curse = targetStats.statusEffects[c];
                damage += curse.magnitude;
            }
        }
        
        //damage the target
        Debug.Log("damage "+damage);
        int intdamage = Mathf.Max((int)Mathf.Round(damage), 1);
        targetStats.health -= intdamage;
        Debug.Log("damaging the target "+intdamage);

        //increase will if bitter
        int bi = targetStats.statusEffects.FindIndex(status => status.type == "bitterness");
        if (bi >= 0)
        {
            StatusEffect bitter = targetStats.statusEffects[bi];
            targetStats.will += intdamage;
        }

        //check if attacker takes damage from thorns
        if (attackerphys){
            int th = targetStats.statusEffects.FindIndex(status => status.type == "thornshield");
            if (th >= 0)
            {
                StatusEffect thorn = targetStats.statusEffects[th];
                casterStats.health -= thorn.magnitude;
            }
        }
    }
}

//chatgpt suggestions for how to implement cooldown

// public void OnTurnStart()
// {
//     foreach (Tome tome in player.TomeArray)
//     {
//         foreach (Spell spell in tome.spells)
//         {
//             spell.ReduceCooldown();
//         }
//     }
// }

// if (!spell.IsAvailable())
// {
//     button.interactable = false;
//     buttonText.text = spell.spellName + $" ({spell.currentCooldown})";
// }
// else
// {
//     button.interactable = true;
//     buttonText.text = spell.spellName;
// }
