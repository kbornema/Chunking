using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SceneChunking.Editor
{
    [CustomEditor(typeof(SC_ChunkRoot)), CanEditMultipleObjects()]
    public class SC_ChunkRootEditor : UnityEditor.Editor
    {   
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            //if(GUILayout.Button("Find nodes"))
            //{
            //    //TODO:
            //    //for (int i = 0; i < targets.Length; i++)
            //    //    (targets[i] as SC_ChunkRoot).FindAllNodes();
            //}

            //if (GUILayout.Button("Activate nodes"))
            //{
            //    for (int i = 0; i < targets.Length; i++)
            //        (targets[i] as SC_ChunkRoot).ActivateAllNodes();
            //}

            //if (GUILayout.Button("Deactivate nodes"))
            //{
            //    for (int i = 0; i < targets.Length; i++)
            //        (targets[i] as SC_ChunkRoot).DeactivateAllNodes();
            //}
        }
    }
}
