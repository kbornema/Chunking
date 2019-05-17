using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SceneChunking.Editor
{   
    [CustomEditor(typeof(SC_SceneSetting))]
    public class SC_SceneSettingEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Scenes to chunks"))
                (target as SC_SceneSetting).ScenesToChunks_Editor();
        }
    }
}