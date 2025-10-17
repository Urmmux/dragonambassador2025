using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Monster))]
public class MonsterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draw the normal inspector first

        Monster stats = (Monster)target;

        if (stats.abilities != null && stats.abilities.Count > 0)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Active Abilities", EditorStyles.boldLabel);

            foreach (Spell spell in stats.abilities)
            {
                if (spell != null)
                    EditorGUILayout.LabelField("• " + spell.spellName);
                else
                    EditorGUILayout.LabelField("• (null spell)");
            }
        }
    }
}