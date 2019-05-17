using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneChunking
{
    public class SC_SceneHandler : MonoBehaviour
    {   
        [SerializeField]
        private SC_SceneSetting _settings = default;
        public SC_SceneSetting ChunkSettings => _settings;

        //TODO: add readonly:
        [SerializeField]
        private List<SC_ChunkRuntimeInfo> _chunkInfos = default;

        private Dictionary<Vector2Int, SC_ChunkRuntimeInfo> _chunkIdToChunkInfoDict;

        //TODO: chunkLoaders:

        private void Awake()
        {
            _chunkIdToChunkInfoDict = new Dictionary<Vector2Int, SC_ChunkRuntimeInfo>();

            var chunksMetaInfo = _settings.GetChunkMetaInfos();

            foreach(var tmpMetaInfo in chunksMetaInfo)
            {       
                var chunkInfo = new SC_ChunkRuntimeInfo(tmpMetaInfo, this);
                _chunkInfos.Add(chunkInfo);
                _chunkIdToChunkInfoDict.Add(tmpMetaInfo.ChunkId, chunkInfo);
            }
        }

        public void RequestLoadChunk(SC_ChunkRuntimeInfo chunk)
        {
            Debug.Assert(chunk != null, "Chunk was null!");
            //TODO:
        }

        public void RequestUnloadChunk(SC_ChunkRuntimeInfo chunk)
        {
            Debug.Assert(chunk != null, "Chunk was null!");
            //TODO:
        }

        public SC_ChunkRuntimeInfo GetChunkInfoAt(Vector2Int id)
        {
            if (_chunkIdToChunkInfoDict.TryGetValue(id, out SC_ChunkRuntimeInfo chunk))
                return chunk;

            Debug.LogWarning("Chunk with id " + id + " does not exist!");
            return null;
        }

        public void RequestLoadChunkAt(Vector2Int id)
        {
            var chunkInfo = GetChunkInfoAt(id);

            if(chunkInfo != null)
                RequestLoadChunk(chunkInfo);
        }

        public void RequestUnloadChunkAt(Vector2Int id)
        {
            var chunkInfo = GetChunkInfoAt(id);

            if (chunkInfo != null)
                RequestUnloadChunk(chunkInfo);
        }
    }
}