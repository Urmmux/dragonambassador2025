using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerFight : MonoBehaviour
{
   List<GameObject> enemies;
   GameObject ally;

   public Camera dragonCam;

   public Camera battleCam;

   public GameObject playerSpritePrefab;

   public GameObject relevantUIscreen;

   public Tome[] tomeArr = new Tome[3];

   public Spell[] spellArr = new Spell[3];

   public static event Action<ButtonInfo[]> RequestButtons;
   public static event Action<ButtonInfo[]> RequestButtonsExit;
   public static event Action ButtonsEnable;
   public static event Action ButtonsDisable;

   //helps to determine how to clean up after battle
   public string typeOfBattle;

   //steps to a fight
   //initialize battlestats for dragons/player
   //assign enemies and allies
   //change texture to battle camera texture and move sprites
   //get player tomes and assign buttons
   //upon button click, assign spells to buttons

   //have enemies take their turn at the start of battle, and allies take their turn after player's cast, then enemies take their turn, etc...
   //after enemy or ally or player takes a turn, decrement all status effect durations if needed

   //remember to move sprites back and switch camera back after a fight

   public void DragonBattle(GameObject UIScreenArg, GameObject enemy, GameObject dragAlly){
      typeOfBattle = "dragon";
      //get components
      BattleStats enemyBattleStats = enemy.GetComponent<BattleStats>();
      BattleStats allyBattleStats = dragAlly.GetComponent<BattleStats>();
      DragStats enemyDragonStats = enemy.GetComponent<DragStats>();
      DragStats allyDragonStats = dragAlly.GetComponent<DragStats>();
      BattleStats playerStats = gameObject.GetComponent<BattleStats>();
      PlayerCore playerCore = gameObject.GetComponent<PlayerCore>();

      //assign dragon battlestats
      enemyBattleStats.type = "dragon";
      enemyBattleStats.affinity = enemyDragonStats.affinity;
      enemyBattleStats.health = 20 + enemyDragonStats.power*2;
      enemyBattleStats.resistance = 5 + Mathf.RoundToInt(enemyDragonStats.power) + enemyDragonStats.vainity;
      enemyBattleStats.defense = 5 + enemyDragonStats.power;
      if (enemyDragonStats.sloth){
         enemyBattleStats.defense += 4;
      }
      enemyBattleStats.tempPower = enemyDragonStats.power;
      enemyBattleStats.will = 10 - enemyDragonStats.brutality - enemyDragonStats.jealousy - (enemyDragonStats.boredom*2) + enemyDragonStats.honor;
      if (enemyDragonStats.sloth){
         enemyBattleStats.will += 4;
      }
      if (enemyDragonStats.moody){
         enemyBattleStats.will += UnityEngine.Random.Range(-5, 4);
      }
      if (enemyDragonStats.ruler){
         enemyBattleStats.will += 4;
      }

      allyBattleStats.type = "dragon";
      allyBattleStats.affinity = allyDragonStats.affinity;
      allyBattleStats.health = 20 + allyDragonStats.power * 2;
      allyBattleStats.resistance = 5 + Mathf.RoundToInt(allyDragonStats.power) + allyDragonStats.vainity;
      allyBattleStats.defense = 5 + allyDragonStats.power;
      if (allyDragonStats.sloth)
      {
         allyBattleStats.defense += 4;
      }
      allyBattleStats.tempPower = allyDragonStats.power;
      allyBattleStats.will = 10 - allyDragonStats.brutality - allyDragonStats.jealousy - (allyDragonStats.boredom * 2) + allyDragonStats.honor;
      if (allyDragonStats.sloth)
      {
         allyBattleStats.will += 4;
      }
      if (allyDragonStats.moody)
      {
         allyBattleStats.will += UnityEngine.Random.Range(-5, 4);
      }
      if (allyDragonStats.ruler)
      {
         allyBattleStats.will += 4;
      }

      //assign player battlestats
      playerStats.type = "player";
      playerStats.affinity = "";
      playerStats.health = playerCore.health;
      playerStats.resistance = playerCore.resistance;
      playerStats.defense = playerCore.defense;
      playerStats.tempPower = playerCore.power;
      playerStats.will = playerCore.will;

      //assign to ally slot and enemy list, spawn minion
      enemies = new List<GameObject>();
      ally = dragAlly;
      enemies.Add(enemy);
      GameObject minion = Instantiate(MonsterLibrary.GetDragonMinion(enemyDragonStats.affinity, enemyDragonStats.wealth));
      enemies.Add(minion);

      //get sprites
      GameObject playerSprite = Instantiate(playerSpritePrefab, new Vector3(-21.5f, -43.3f, 2f), Quaternion.identity);
      GameObject allySprite = dragAlly.transform.GetChild(0).gameObject;
      GameObject enemySprite = enemy.transform.GetChild(0).gameObject;
      GameObject minionSprite = minion.transform.GetChild(0).gameObject;

      // move sprites to positions
      allySprite.SetActive(true);
      enemySprite.SetActive(true);
      allySprite.transform.position = allySprite.transform.position + new Vector3(-20f, -3, 0);
      enemySprite.transform.position = enemySprite.transform.position + new Vector3(-22f, 0, 0);
      minionSprite.transform.position = minionSprite.transform.position + new Vector3(-20f, 0, 0);

      relevantUIscreen = UIScreenArg;
      SetCamerasBattle();

      //get player tomes and assign buttons
      tomeArr = playerCore.tomeArr;
      SetButtonsTomes(tomeArr);

      StartCoroutine(EnemyTurn());
   }

   public IEnumerator EnemyTurn(){
      Debug.Log("Enemies Acting!");

      ButtonsDisable.Invoke();
      foreach (GameObject enemy in enemies)
      {
         Debug.Log("Enemy Found");
         yield return EnemyAct(enemy);
      }
      ButtonsEnable.Invoke();
      //check if either no enemies, or if player health is zero
      //BattleOverCheck()
   }

   public IEnumerator EnemyAct(GameObject enemy)
   {
      yield return new WaitForSeconds(1);
      Debug.Log("enemy acting!");
      List<Spell> possibleAbilities = GetPossibleAbilities(enemy);
      foreach (var s in possibleAbilities)
      {
         Debug.Log($"Available spell: {s.spellName}");
      }
      Spell chosenSpell = possibleAbilities[UnityEngine.Random.Range(0, possibleAbilities.Count)];
      GameObject target = SelectTarget(chosenSpell, enemy);
      chosenSpell.Cast(enemy, target);
      Debug.Log("casting " + chosenSpell.spellName + " on " + target.name);
      chosenSpell.StartCooldown();
      Text text = relevantUIscreen.transform.GetChild(1).GetComponent<Text>();
      //change if AOE
      text.text += "\n" + GetTargetName(enemy) + " uses " + chosenSpell.spellName + " on " + GetTargetName(target);
      //proc status effects and reduce duration by one
   }

   public IEnumerator AllyAct(){
      ButtonsDisable.Invoke();

      yield return new WaitForSeconds(1);
      Debug.Log("ally acting!");
      List<Spell> possibleAbilities = GetPossibleAbilities(ally);
      foreach (var s in possibleAbilities) {
         Debug.Log($"Available spell: {s.spellName}");
      }
      Spell chosenSpell = possibleAbilities[UnityEngine.Random.Range(0, possibleAbilities.Count)];
      GameObject target = SelectTarget(chosenSpell, ally);
      chosenSpell.Cast(ally, target);
      Debug.Log("casting "+ chosenSpell.spellName + " on " +target.name);
      chosenSpell.StartCooldown();
      Text text = relevantUIscreen.transform.GetChild(1).GetComponent<Text>();
      //change if AOE
      text.text += "\n" + GetTargetName(ally) + " uses " + chosenSpell.spellName + " on " + GetTargetName(target);

      ButtonsEnable.Invoke();
      //BattleOverCheck
      //proc status effects on ally and reduce duration by one
      StartCoroutine(EnemyTurn());
   }

   public GameObject SelectTarget(Spell chosenSpell, GameObject caster){
      //modify this function to make NPC's smarter
      //differentiate between support abilities and attacks
      //remove positive or negative status effects
      //don't target enemies with 0 health
      if (caster == ally) {
         // Ally supports player team; target an enemy randomly
         return enemies[UnityEngine.Random.Range(0, enemies.Count)];
      } else {
         // Enemy targets player or their ally randomly
         List<GameObject> possibleTargets = new List<GameObject>();
         possibleTargets.Add(gameObject);
         if (ally != null) possibleTargets.Add(ally);
         return possibleTargets[UnityEngine.Random.Range(0, possibleTargets.Count)];
      }
   }
   public List<Spell> GetPossibleAbilities(GameObject caster, bool reduceCooldown = true){
      BattleStats bStats = caster.GetComponent<BattleStats>();
      List<Spell> allSpells = new List<Spell>();

      // Get spells based on type
      if (bStats.type == "dragon") {
         allSpells = caster.GetComponent<DragStats>().abilities;
      } else if (bStats.type == "monster") {
         allSpells = caster.GetComponent<Monster>().abilities;
      } else if (bStats.type == "hero") {
         Debug.Log("GetPossibleAbilities not implemented for heroes.");
         return new List<Spell>();
      } else {
         Debug.Log("GetPossibleAbilities not implemented for unknown type.");
         return new List<Spell>();
      }
      // Check for silence
      bool isSilenced = bStats.statusEffects.Exists(effect => effect.type == "silent");
      // Filter spells: cooldown == 0 AND not affected by silence OR caster isn't silenced
      List<Spell> usableSpells = allSpells.FindAll(spell => spell.cooldownCounter == 0 && (!spell.affectedBySilence || !isSilenced));
      //after filtered by cooldown, then reduce cooldown
      if(reduceCooldown){
         foreach (Spell spell in allSpells) {
         spell.ReduceCooldown();
         }
      }
      return usableSpells;
   }

   void SetCamerasBattle(){
      dragonCam.gameObject.SetActive(false);
      battleCam.gameObject.SetActive(true);
      relevantUIscreen.transform.GetChild(2).gameObject.SetActive(false);
      relevantUIscreen.transform.GetChild(3).gameObject.SetActive(true);
   }

   void SetButtonsTomes(Tome[] tomeArr){
      ButtonInfo[] options = new ButtonInfo[3];
        options[0] = new ButtonInfo
        {
            label = tomeArr[0].tomeName,
            onClick = () => SetButtonsSpells(tomeArr[0])
        };
        options[1] = new ButtonInfo
        {
            label = tomeArr[0].tomeName,
            onClick = () => SetButtonsSpells(tomeArr[1])
        };
        options[2] = new ButtonInfo
        {
            label = tomeArr[0].tomeName,
            onClick = () => SetButtonsSpells(tomeArr[2])
        };

      RequestButtons.Invoke(options);
   }

   void SetButtonsSpells(Tome selectedTome){
      spellArr = selectedTome.spells;
      ButtonInfo[] options = new ButtonInfo[4];
      for (int i = 0; i < 3; i++)
      {
         int capturedIndex = i;
         if (spellArr[i].IsReady()){
            options[i] = new ButtonInfo{
               label = spellArr[capturedIndex].spellName,
               onClick = () => SetButtonsTargets(spellArr[capturedIndex])
            };
         } else {
            options[i] = new ButtonInfo{
               label = $"{spellArr[capturedIndex].spellName} ({spellArr[capturedIndex].cooldownCounter})",
               onClick = () => Debug.Log("Spell is still on cooldown!")
            };
         };
      }
      options[3] = new ButtonInfo
      {
         label = "back",
         onClick = () => SetButtonsTomes(tomeArr)
      };

      RequestButtons.Invoke(options);
   }

   void SetButtonsSpells(Spell[] spellArr){
      ButtonInfo[] options = new ButtonInfo[4];

      BattleStats stats = this.gameObject.GetComponent<BattleStats>();
      int t = stats.statusEffects.FindIndex(status => status.type == "trance");

      for (int i = 0; i < 3; i++)
      {
         int capturedIndex = i;

         if (t >= 0){
            if (spellArr[i].spellName == "Divine Blade"){
               options[i] = new ButtonInfo{
               label = spellArr[capturedIndex].spellName,
               onClick = () => SetButtonsTargets(spellArr[capturedIndex])
               };
            } 
            continue;
         }

         if (spellArr[i].IsReady()){
            options[i] = new ButtonInfo{
               label = spellArr[capturedIndex].spellName,
               onClick = () => SetButtonsTargets(spellArr[capturedIndex])
            };
         } else {
            options[i] = new ButtonInfo{
               label = $"{spellArr[capturedIndex].spellName} cooldown {spellArr[capturedIndex].cooldownCounter}",
               onClick = () => Debug.Log("Spell is still on cooldown!")
            };
         };
      }

      options[3] = new ButtonInfo
      {
         label = "back",
         onClick = () => SetButtonsTomes(tomeArr)
      };

      RequestButtons.Invoke(options);
   }

   void SetButtonsTargets(Spell spell){
      List<ButtonInfo> options = new List<ButtonInfo>();
      string targetName;

      if (spell.canTargetSelf){
      targetName = GetTargetName(this.gameObject);
      options.Add(new ButtonInfo{
         label = targetName,
         onClick = () => CastSpell(spell, this.gameObject, this.gameObject)
      });
      }

      if (spell.canTargetEnemy){
         foreach (GameObject enemy in enemies)
         {
            targetName = GetTargetName(enemy);
            options.Add(new ButtonInfo
            {
                  label = targetName,
                  onClick = () => CastSpell(spell, enemy, this.gameObject)
            });
         }
      }

      if (ally != null && spell.canTargetAlly)
      {
         targetName = GetTargetName(ally);
         options.Add(new ButtonInfo
         {
               label = targetName,
               onClick = () => CastSpell(spell, ally, this.gameObject)
         });
      }

      options.Add(new ButtonInfo
      {
         label = "Back",
         onClick = () => SetButtonsSpells(spellArr)
      });

      RequestButtons.Invoke(options.ToArray());
   }

   public void CastSpell(Spell spell, GameObject target, GameObject caster){
      Debug.Log("casting spell "+spell.spellName);
      spell.Cast(caster, target);
      ReducePlayerCooldowns();
      spell.StartCooldown();
      //perform check if enemies are still present
      //BattleOverCheck
      //proc status effects on player where applicable and reduce duration of them by 1
      SetButtonsTomes(tomeArr);
      Text text = relevantUIscreen.transform.GetChild(1).GetComponent<Text>();
      text.text = "You used " + spell.spellName + " on " + GetTargetName(target);
      StartCoroutine(AllyAct());
   }

   public string GetTargetName(GameObject target){
      //need to implement every NPC type here
      BattleStats bStats = target.GetComponent<BattleStats>();
      if (bStats.type == "player"){
         return target.GetComponent<PlayerCore>().playerName;
      } else if (bStats.type == "dragon"){
         return target.GetComponent<DragStats>().dragName;
      } else if (bStats.type == "monster"){
         return target.GetComponent<Monster>().monName;
      } else if (bStats.type == "hero"){
         // return target.GetComponent<Hero>().heroName;
         return "target not implemented correctly in PlayerFight";
      } else {
         return "target not implemented correctly in PlayerFight";
      }
   }

   public void ReducePlayerCooldowns()
   {
      foreach (Tome tome in tomeArr){
         spellArr = tome.spells;
         foreach (Spell spell in spellArr)
         {
            spell.ReduceCooldown();
         }
      }
   }
    
}
