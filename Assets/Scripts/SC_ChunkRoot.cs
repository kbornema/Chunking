using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneChunking
{   
    [ExecuteInEditMode]
    public class SC_ChunkRoot : MonoBehaviour
    {
        //TODO: maybe get rid of this list? and enable child objects individually?
        [SerializeField]
        private List<SC_ChunkNode> _chunkNodes = default;

//        private void Awake()
//        {
//            ActivateAllNodes();
//        }

//        public void ActivateAllNodes()
//        {
//            for (int i = 0; i < _chunkNodes.Count; i++)
//                _chunkNodes[i].ActivateNode();
//        }

//        public void DeactivateAllNodes()
//        {
//            for (int i = 0; i < _chunkNodes.Count; i++)
//                _chunkNodes[i].DeactivateNode();

//#if UNITY_EDITOR
//            if(!Application.isPlaying)
//                UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(gameObject.scene);
//#endif
//        }
    }
}