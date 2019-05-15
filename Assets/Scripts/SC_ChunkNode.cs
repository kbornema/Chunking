using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneChunking
{
    public class SC_ChunkNode : MonoBehaviour
    {
        //TODO: idea: give a chunkNode an importance -> high importance, earlier load and unloaded as last.

        [SerializeField]
        private List<SC_ChunkNode> _children = default;

        public void ActivateNode()
        {
            gameObject.SetActive(true);

            //TODO: activate children nodes over several frames, also activate non node children
        }

        public void DeactivateNode()
        {
            gameObject.SetActive(false);

            //TODO: deactivate children nodes over several frames, also activate non node children
        }
    }
}