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
        [SerializeField]
        private ChunkState _state = ChunkState.None;

        public void FindAllNodes()
        {


            //TODO: only save root nodes here, assign child nodes of nodes at that place
            //_chunkNodes.Clear();
        }

        public void ActivateAllNodes()
        {
            _state = ChunkState.Loading;

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