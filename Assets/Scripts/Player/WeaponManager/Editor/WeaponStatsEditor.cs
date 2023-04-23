using UnityEditor;

[CustomEditor(typeof(WeaponStats))]
public class WeaponStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("damage"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponPrefab"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponType"));

        serializedObject.ApplyModifiedProperties();
    }
}