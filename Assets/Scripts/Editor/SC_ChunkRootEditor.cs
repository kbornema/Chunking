using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SceneChunking.Editor
{
    [CustomEditor(typeof(SC_ChunkRoot))]
    public class SC_ChunkRootEditor : UnityEditor.Editor
    {
        //TODO: find nodes automatically:

        //TODO: deactivate all nodes:

        //TODO: activate all nodes:

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(GUILayout.Button("Find nodes"))
            {
                (target as SC_ChunkRoot).FindAllNodes();
            }

            if (GUILayout.Button("Activate nodes"))
            {
                (target as SC_ChunkRoot).ActivateAllNodes();
            }

            if (GUILayout.Button("Deactivate nodes"))
            {
                (target as SC_ChunkRoot).DeactivateAllNodes();
            }
        }
    }
}
