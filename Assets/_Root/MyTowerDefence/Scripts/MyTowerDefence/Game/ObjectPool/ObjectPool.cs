using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjectPool
{
    internal sealed class ObjectPool : IDisposable
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly Transform _root;
        private readonly Transform _startPoint;

        public ObjectPool(GameObject prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;
        }

        public GameObject Pop(GameObject prefab, Vector3 startPoint)
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(prefab,startPoint, Quaternion.identity);
                go.name = prefab.name;
            }
            else
            {
                go = _stack.Pop();
                go.transform.position = startPoint;
            }

            go.SetActive(true);
            go.transform.SetParent(null);
            return go;
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.transform.SetParent(_root);
            go.SetActive(false);
        }


        public void Dispose()
        {
            for (int i = 0; i < _stack.Count; i++)
            {
                var gameObject = _stack.Pop();
                Object.Destroy(gameObject);
            }
            Object.Destroy(_root.gameObject);
        }
    }
}
