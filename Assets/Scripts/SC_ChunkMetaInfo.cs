using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneChunking
{
    [System.Serializable]
    public class SC_ChunkMetaInfo
    {
        [Header("Runtime")]
        [SerializeField]
        private string _sceneChunkName;
        public string SceneChunkName => _sceneChunkName;

        [SerializeField]
        private Vector2Int _chunkId;
        public Vector2Int ChunkId => _chunkId;

#if UNITY_EDITOR
        //storing the asset itself instead of the asset path, so that the asset path is up to date when location or name changes:
        [Header("Editor")]
        [SerializeField]
        private UnityEditor.SceneAsset _sceneAsset_Editor = null;
        public UnityEditor.SceneAsset SceneAsset_Editor => _sceneAsset_Editor;

        public string GetSceneAssetPath_Editor()
        {
            if (_sceneAsset_Editor)
                return UnityEditor.AssetDatabase.GetAssetPath(_sceneAsset_Editor);

            return null;
        }
#endif

        public void Set_Editor(string chunkName, Vector2Int chunkId)
        {
            _sceneChunkName = chunkName;
            _chunkId = chunkId;
        }
    }
}