using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public interface IViewServices 
    {
        T Instantiate<T>(GameObject prefab,Vector3 startPoint);

        void Destroy(GameObject value);

        void Dispose(GameObject prefab);
    }
}
