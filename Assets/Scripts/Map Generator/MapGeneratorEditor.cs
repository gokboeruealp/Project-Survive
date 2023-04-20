using UnityEditor;
using UnityEngine;

namespace GokboerueTools.MapGenerator
{
    [CustomEditor(typeof(MapGenerator))]
    public class MapGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            MapGenerator mapGen = (MapGenerator)target;

            DrawDefaultInspector();

            if (GUILayout.Button("Generate"))
            {
                mapGen.DrawMapInEditor();
            }

            if (GUILayout.Button("Clear"))
            {
                mapGen.ClearMapInEditor();
            }
        }
    }
}