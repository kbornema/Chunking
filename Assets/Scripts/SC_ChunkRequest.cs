using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneChunking
{
    public class SC_ChunkRequest
    {
        public enum Mode { Load, Unload }

        private SC_ChunkMetaInfo _metaInfo;
        public SC_ChunkMetaInfo MetaInfo => _metaInfo;

        private Mode _mode;
        public Mode RequestMode => _mode;

        public SC_ChunkRequest(SC_ChunkMetaInfo info, Mode requestMode)
        {
            _metaInfo = info;
            _mode = requestMode;
        }
    }
}