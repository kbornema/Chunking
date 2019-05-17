using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneChunking
{   
    public class SC_ChunkLoader : MonoBehaviour
    {   
        public enum State { Busy, Idle }

        //TODO: add readonly:
        [SerializeField]
        private State _state = State.Idle;
        public State GetState() => _state;

        private SC_ChunkRuntimeInfo _chunkInfo = default;
        public SC_ChunkRuntimeInfo ChunkInfo => _chunkInfo;

        //TODO: load unload something:
        public void StartTask()
        {
            Debug.Assert(_state == State.Idle);
        }

        //private void Update()
        //{
        //    if(_objectsToLoad.Count > 0)
        //    {
        //        var currentList = _objectsToLoad.Peek();

        //        //list is empty: loading has finished:
        //        if(currentList.Count <= 0)
        //        {
        //            _objectsToLoad.Dequeue();
        //        }

        //        //pick one element after another and activate one each frame:
        //        else
        //        {
        //            var index = currentList.Count - 1;
        //            var next = currentList[index];

        //            const bool ACTIVATE = true;

        //            var childs = Activate(next.Obj, ACTIVATE);

        //            if (childs.Count > 0)
        //                _objectsToLoad.Enqueue(childs);

        //            currentList.RemoveAt(index);
        //        }
        //    }
        //}

        private IEnumerator LoadSceneChunkRoutine(SC_ChunkRequest request)
        {
            
            yield return null;
            //Debug.Log("=");
            //var asyncOperation = request.Operation;

            //Debug.Log(asyncOperation.progress);

            //while(!asyncOperation.isDone)
            //{   
            //    float percent = asyncOperation.progress;

            //    Debug.Log(percent);

            //    if(percent >= 0.9f)
            //    {

            //    }

            //    yield return new WaitForEndOfFrame();
            //}
        }

        //private List<LoadableObject> PrepareRootObjects(Scene scene)
        //{
        //    List<GameObject> rootObjects = new List<GameObject>();
        //    scene.GetRootGameObjects(rootObjects);

        //    List<LoadableObject> resultOrder = new List<LoadableObject>();

        //    List<LoadableObject> nodes = new List<LoadableObject>();

        //    for (int i = 0; i < rootObjects.Count; i++)
        //    {
        //        var tmpObj = rootObjects[i];
        //        var tmpLoadable = new LoadableObject(tmpObj);

        //        if (tmpLoadable.Node)
        //            nodes.Add(tmpLoadable);
        //        else
        //            resultOrder.Add(tmpLoadable);

        //    }

        //    //add nodes afterwards:
        //    resultOrder.AddRange(nodes);
        //    return resultOrder;
        //}

        ///// <summary>
        ///// Activates the given GameObject and returns the order of child objects to be activated.
        ///// </summary>
        //private List<LoadableObject> Activate(GameObject obj, bool value)
        //{
        //    obj.SetActive(value);

        //    List<LoadableObject> childLoadObjects = new List<LoadableObject>();
        //    List<LoadableObject> childNodeObjects = new List<LoadableObject>();

        //    for (int i = 0; i < obj.transform.childCount; i++)
        //    {
        //        var childGo = obj.transform.GetChild(i).gameObject;
        //        var tmpLoadable = new LoadableObject(childGo);

        //        if (tmpLoadable.Node)
        //            childNodeObjects.Add(tmpLoadable);
        //        else
        //            childLoadObjects.Add(tmpLoadable);
        //    }

        //    childLoadObjects.AddRange(childNodeObjects);
        //    return childLoadObjects;
        //}

        //private class LoadableObject
        //{
        //    public GameObject Obj;
        //    public SC_ChunkNode Node;

        //    public LoadableObject(GameObject obj)
        //    {
        //        Obj = obj;
        //        Node = obj.GetComponent<SC_ChunkNode>();
        //    }
        //}
    }
}