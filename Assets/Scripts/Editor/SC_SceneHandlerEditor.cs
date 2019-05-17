using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SceneChunking
{   
    [CustomEditor(typeof(SC_SceneHandler))]
    public class SC_SceneHandlerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!Application.isPlaying)
            {
                if (GUILayout.Button("Load all chunks (Editor)"))
                    LoadAll((target as SC_SceneHandler).ChunkSettings.GetChunkMetaInfos());

                if (GUILayout.Button("Unload all chunks (Editor)"))
                    UnloadAll((target as SC_SceneHandler).ChunkSettings.GetChunkMetaInfos());
            }

        }

        private void LoadAll(List<SC_ChunkMetaInfo> chunkMetaInfos)
        {
            for (int i = 0; i < chunkMetaInfos.Count; i++)
            {
                var sceneAssetPath = chunkMetaInfos[i].GetSceneAssetPath_Editor();

                if (!String.IsNullOrEmpty(sceneAssetPath))
                    UnityEditor.SceneManagement.EditorSceneManager.OpenScene(sceneAssetPath, UnityEditor.SceneManagement.OpenSceneMode.Additive);
            }
        }

        private void UnloadAll(List<SC_ChunkMetaInfo> chunkMetaInfos)
        {
            for (int i = 0; i < chunkMetaInfos.Count; i++)
            {
                var sceneName = chunkMetaInfos[i].SceneChunkName;
          
                if (!String.IsNullOrEmpty(sceneName))
                {
                    var scene = UnityEditor.SceneManagement.EditorSceneManager.GetSceneByName(sceneName);

                    if (scene != null)
                        UnityEditor.SceneManagement.EditorSceneManager.CloseScene(scene, true);
                }
            }
        }
    }
}