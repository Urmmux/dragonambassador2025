using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DragStats))]
public class DragStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draw the normal inspector first

        DragStats stats = (DragStats)target;

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