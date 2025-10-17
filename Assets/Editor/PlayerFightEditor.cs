using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerFight))]
public class PlayerFightEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draw the normal inspector first

        PlayerFight pfight = (PlayerFight)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Active Spells", EditorStyles.boldLabel);
        
        foreach (Spell spell in pfight.spellArr)
        {
            if (spell != null)
                EditorGUILayout.LabelField("• " + spell.spellName);
            else
                EditorGUILayout.LabelField("• (null spell)");
        }
    }
}