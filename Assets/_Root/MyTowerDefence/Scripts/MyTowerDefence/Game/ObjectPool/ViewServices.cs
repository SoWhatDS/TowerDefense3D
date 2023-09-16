using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjectPool
{
    internal sealed class ViewServices : IViewServices
    {
        private readonly Dictionary<string, ObjectPool> _viewCache
            = new Dictionary<string, ObjectPool>();

        public T Instantiate<T>(GameObject prefab,Vector3 startPoint)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            if (viewPool.Pop(prefab,startPoint).TryGetComponent(out T component))
            {
                return component;
            }

            throw new InvalidOperationException($"{typeof(T)} not found");
        }

        public void Destroy(GameObject value)
        {
            _viewCache[value.name].Push(value);
        }

        public void Dispose(GameObject prefab)
        {
            if (_viewCache.ContainsKey(prefab.name))
            {
                _viewCache[prefab.name].Dispose();
            }
        }
    }
}
