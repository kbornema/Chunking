using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneChunking
{
    [System.Serializable]
    public class SC_ChunkInfo
    {
        /// <summary> Name of the scene chunk, that can be loaded at runtime when added to BuildSettings. </summary>
        public string SceneChunkName;
        public Vector2Int ChunkId;

        public SC_ChunkInfo(string sceneChunkName, Vector2Int chunkId)
        {
            SceneChunkName = sceneChunkName;
            ChunkId = chunkId;
        }
    }
}