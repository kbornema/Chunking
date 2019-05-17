using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneChunking
{   
    public class SC_ChunkNode : MonoBehaviour
    {
        public enum Task { None, Loading, Unloading }

        //TODO: idea: give a chunkNode an importance -> high importance, earlier load and unloaded as last.

        public void ActivateNodeDelayed(bool value)
        {
            //if (gameObject.activeSelf == value)
            //    return;

            //if (Application.isPlaying)
            //{
            //    //TODO:
            //}

            //else
            //{
            //    ActivateNodeImmediately(value);
            //}
        }

        /// <summary> Activates this node, all child transforms and all sub-nodes immediately. </summary>
        public void ActivateNodeImmediately(bool value)
        {
            gameObject.SetActive(value);

            Queue<SC_ChunkNode> childNodes = new Queue<SC_ChunkNode>();

            //first: activate all child transforms that are not nodes:
            for (int i = 0; i < transform.childCount; i++)
            {
                var childGameObject = transform.GetChild(i).gameObject;
                var childChunkNode = childGameObject.GetComponent<SC_ChunkNode>();

                if (childChunkNode)
                    childNodes.Enqueue(childChunkNode);
                else
                    childGameObject.SetActive(value);
            }

            //second: activate all child nodes:
            while (childNodes.Count > 0)
                childNodes.Dequeue().ActivateNodeDelayed(value);
        }
    }
}