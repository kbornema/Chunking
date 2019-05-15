using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SceneChunking
{
    [CreateAssetMenu]
    public class SC_SceneSetting : ScriptableObject
    {
        [SerializeField]
        private string _baseChunkName = "Scene_A_";
        public string BaseChunkName => _baseChunkName;

        [SerializeField]
        private List<SC_ChunkInfo> _chunks = default;
        public List<SC_ChunkInfo> GetChunks() => _chunks;

        //TODO: add global settings. e.g. chunk size. Speed or something?

#if UNITY_EDITOR
        [Header("Editor Only")]
        [SerializeField]
        private List<UnityEditor.SceneAsset> _chunkScenes = default;

        public void ScenesToChunks()
        {
            _chunks.Clear();

            char[] split = { '_' };

            for (int i = 0; i < _chunkScenes.Count; i++)
            {
                string chunkName = _chunkScenes[i].name;
                var splits = chunkName.Split(split, StringSplitOptions.RemoveEmptyEntries);

                var x = int.Parse(splits[splits.Length - 2]);
                var y = int.Parse(splits[splits.Length - 1]);

                Vector2Int chunkId = new Vector2Int(x, y);

                if(!chunkName.StartsWith(_baseChunkName))
                {
                    Debug.LogError("Scene chunks must start with '" + _baseChunkName + "'. But started with: '" + chunkName + "'");
                    continue;
                }
                _chunks.Add(new SC_ChunkInfo(chunkName, chunkId));
            }
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