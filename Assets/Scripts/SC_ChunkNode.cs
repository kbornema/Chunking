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
        private List<SC_ChunkNode> _childNodes = default;

        private void Update()
        {
            
        }

        public void ActivateNode()
        {
            ActivateNode(true);
        }

        public void DeactivateNode()
        {
            ActivateNode(false);
        }

        public void ActivateNode(bool value)
        {
            if (gameObject.activeSelf == value)
                return;

            gameObject.SetActive(value);

            if (Application.isPlaying)
            {
                //TODO:
            }

            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    var childGameObject = transform.GetChild(i).gameObject;

                    //chunk nodes will be handles differently:
                    if (childGameObject.GetComponent<SC_ChunkNode>() == null)
                        childGameObject.SetActive(value);
                }

                for (int i = 0; i < _childNodes.Count; i++)
                    _childNodes[i].ActivateNode(value);
            }
        }
    }
}