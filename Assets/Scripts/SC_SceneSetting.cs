using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SceneChunking
{
    /// <summary> Holds the information about all chunks that belong to a single scene. </summary>
    [CreateAssetMenu]
    public class SC_SceneSetting : ScriptableObject
    {   
        [SerializeField]
        private string _baseChunkName = "Scene_A_";
        public string BaseChunkName => _baseChunkName;

        [SerializeField]
        private List<SC_ChunkMetaInfo> _chunkMetaInfos = default;
        public List<SC_ChunkMetaInfo> GetChunkMetaInfos() => _chunkMetaInfos;

        //TODO: add global settings. e.g. chunk size. Speed or something?

#if UNITY_EDITOR
        private Dictionary<string, string> _sceneNameToSceneAssetPath_Editor;

        /// <summary>
        /// Automatically fills scene/chunk name and id from the scene assets. 
        /// SceneAssets must obey the naming convention: "BaseChunkName_x_y". Where x and y are ids of the chunk.
        /// </summary>
        public void ScenesToChunks_Editor()
        {       
            char[] split = { '_' };

            for (int i = 0; i < _chunkMetaInfos.Count; i++)
            {
                var curChunkInfo = _chunkMetaInfos[i];
                var curChunkScene = curChunkInfo.SceneAsset_Editor;
                string chunkName = curChunkScene.name;

                var splits = chunkName.Split(split, StringSplitOptions.RemoveEmptyEntries);

                var x = int.Parse(splits[splits.Length - 2]);
                var y = int.Parse(splits[splits.Length - 1]);

                Vector2Int chunkId = new Vector2Int(x, y);

                if(!chunkName.StartsWith(_baseChunkName))
                {
                    Debug.LogError("Scene chunks must start with '" + _baseChunkName + "'. But started with: '" + chunkName + "'");
                    continue;
                }

                curChunkInfo.Set_Editor(chunkName, chunkId);
            }
        }

        /// <summary> Given a name of a chunk/scene, it returns the asset path of the related SceneAsset. </summary>
        public string GetSceneAssetPathFromSceneName_Editor(string sceneName)
        {
            if (_sceneNameToSceneAssetPath_Editor == null)
            {
                _sceneNameToSceneAssetPath_Editor = new Dictionary<string, string>();

                for (int i = 0; i < _chunkMetaInfos.Count; i++)
                    _sceneNameToSceneAssetPath_Editor.Add(_chunkMetaInfos[i].SceneChunkName, _chunkMetaInfos[i].GetSceneAssetPath_Editor());
            }

            if(!_sceneNameToSceneAssetPath_Editor.TryGetValue(sceneName, out string scenePath))
            {
                Debug.LogWarning("Could not find chunk/scene with name " + sceneName + ". Check the related SC_SceneSetting.", this);
            }

            return scenePath;
        }

        //TODO:

        //[Button("PrepareScenes")]
        //private void PrepareScenes()
        //{
        //    foreach(var chunk in _chunks)
        //    {
        //        var sceneName = chunk.ChunkName;
        //        EditorSceneManager.OpenScene(sceneName);

        //        var scene = EditorSceneManager.GetSceneByName(sceneName);

        //        List<GameObject> rootObjects = new List<GameObject>();
        //        scene.GetRootGameObjects(rootObjects);

        //        foreach(var root in rootObjects)
        //            root.SetActive(false);

        //        EditorSceneManager.SaveScene(scene);
        //    }
        //}
#endif
    }
}