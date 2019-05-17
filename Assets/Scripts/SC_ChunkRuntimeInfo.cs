using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SceneChunking
{   
    /// <summary>
    /// Runtime information about a chunk, if its loaded, being unloaded etc.
    /// </summary>
    [System.Serializable]
    public class SC_ChunkRuntimeInfo
    {
        public enum State { NotLoaded, Loading, Unloading, Loaded }

        [SerializeField]
        private SC_ChunkMetaInfo _metaInfo;
        public SC_ChunkMetaInfo MetaInfo => _metaInfo;

        [SerializeField]
        private State _state = State.NotLoaded;
        public State ChunkState => _state;

        private SC_SceneHandler _sceneHandler;
            
        public SC_ChunkRuntimeInfo(SC_ChunkMetaInfo metaInfo, SC_SceneHandler handler)
        {
            _metaInfo = metaInfo;
            _sceneHandler = handler;
        }

        public void RequestLoad()
        {
            _sceneHandler.RequestLoadChunk(this);
        }

        public void RequestUnload()
        {
            _sceneHandler.RequestUnloadChunk(this);
        }
    }
}
