using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneChunking
{   
    public class SC_ChunkRoot : MonoBehaviour
    {
        public enum ChunkState
        {
            None,
            Loading,
            Unloading,
            Ready
        }

        [SerializeField]
        private List<SC_ChunkNode> _chunkNodes = default;

        public void FindAllNodes()
        {
            //TODO:
            //_chunkNodes.Clear();
        }

        public void ActivateAllNodes()
        {
            for (int i = 0; i < _chunkNodes.Count; i++)
                _chunkNodes[i].ActivateNode();
        }

        public void DeactivateAllNodes()
        {
            for (int i = 0; i < _chunkNodes.Count; i++)
                _chunkNodes[i].DeactivateNode();
        }
    }
}