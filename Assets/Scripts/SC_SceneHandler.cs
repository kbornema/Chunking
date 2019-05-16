using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneChunking
{
    public class SC_SceneHandler : MonoBehaviour
    {
        [SerializeField]
        private SC_SceneSetting _settings = default;

        private List<SC_ChunkRequest> _activeChunkRequests = new List<SC_ChunkRequest>();

        private HashSet<Vector2Int> _requestedChunks = new HashSet<Vector2Int>();
        private HashSet<Vector2Int> _loadedChunks = new HashSet<Vector2Int>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
                LoadAllChunks();

            if (Input.GetKeyDown(KeyCode.P))
                UnloadAllChunks();

            for (int i = _activeChunkRequests.Count - 1; i >= 0; i--)
            {
                if (_activeChunkRequests[i].Operation.isDone)
                {
                    if (_activeChunkRequests[i].RequestMode == SC_ChunkRequest.Mode.Load)
                        ChunkLoaded(_activeChunkRequests[i]);
                    else
                        ChunkUnloaded(_activeChunkRequests[i]);

                    _activeChunkRequests.RemoveAt(i);
                }
            }
        }

        public void TryLoadChunkAt(Vector2Int id)
        {
            if (_loadedChunks.Contains(id))
                return;

            if (_requestedChunks.Contains(id))
                return;

            string chunkName = _settings.BaseChunkName + id.x + "_" + id.y;
            var sceneLoadOperation = SceneManager.LoadSceneAsync(chunkName, LoadSceneMode.Additive);

            if (sceneLoadOperation != null)
                CreateChunkRequest(chunkName, id, SC_ChunkRequest.Mode.Load, sceneLoadOperation);
        }

        private void TryUnloadChunkAt(Vector2Int id)
        {
            if (!_loadedChunks.Contains(id))
                return;

            if (_requestedChunks.Contains(id))
                return;

            string chunkName = _settings.BaseChunkName + id.x + "_" + id.y;
            var sceneLoadOperation = SceneManager.UnloadSceneAsync(chunkName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);

            if (sceneLoadOperation != null)
                CreateChunkRequest(chunkName, id, SC_ChunkRequest.Mode.Unload, sceneLoadOperation);
        }

        private void CreateChunkRequest(string chunkName, Vector2Int id, SC_ChunkRequest.Mode mode, AsyncOperation sceneLoadOperation)
        {
            _activeChunkRequests.Add(new SC_ChunkRequest(new SC_ChunkInfo(chunkName, id), mode, sceneLoadOperation));
            _requestedChunks.Add(id);
        }

        private void ChunkLoaded(SC_ChunkRequest sceneChunkRequest)
        {
            Debug.Log("Loaded scene chunk: " + sceneChunkRequest.Info.SceneChunkName);
            _loadedChunks.Add(sceneChunkRequest.Info.ChunkId);
            _requestedChunks.Remove(sceneChunkRequest.Info.ChunkId);
        }

        private void ChunkUnloaded(SC_ChunkRequest sceneChunkRequest)
        {
            Debug.Log("Unloaded scene chunk: " + sceneChunkRequest.Info.SceneChunkName);
            _loadedChunks.Remove(sceneChunkRequest.Info.ChunkId);
            _requestedChunks.Remove(sceneChunkRequest.Info.ChunkId);
        }

        private void LoadAllChunks()
        {
            var chunks = _settings.GetChunks();

            foreach (var chunk in chunks)
                TryLoadChunkAt(chunk.ChunkId);
        }

        private void UnloadAllChunks()
        {
            var chunks = _settings.GetChunks();

            foreach (var chunk in chunks)
                TryUnloadChunkAt(chunk.ChunkId);
        }
    }
}