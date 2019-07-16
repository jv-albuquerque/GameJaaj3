using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelController))]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelController levelController = (LevelController)target;

        GUILayout.BeginHorizontal();

            if (GUILayout.Button("Generated"))
            {
                levelController.Generate();
            }

            if (GUILayout.Button("Clear"))
            {
                levelController.Clear();
            }

        GUILayout.EndHorizontal();
    }
}
