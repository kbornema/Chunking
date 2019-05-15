using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneChunking
{
    public class SC_ChunkRequest
    {
        public enum Mode { Load, Unload }

        public SC_ChunkInfo Info;
        public AsyncOperation Operation;
        public Mode RequestMode;

        public SC_ChunkRequest(SC_ChunkInfo info, Mode requestMode, AsyncOperation sceneLoadOperation)
        {
            Info = info;
            Operation = sceneLoadOperation;
            RequestMode = requestMode;
        }
    }
}