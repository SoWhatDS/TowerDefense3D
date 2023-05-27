
using UnityEngine;
using System;
using Object = UnityEngine.Object;
using System.Collections.Generic;

internal abstract class BaseController : IDisposable
{
    private List<BaseController> _baseControllers;
    private List<GameObject> _gameObjects;
    private bool _isDisposed;

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        _isDisposed = true;

        DisposeBaseControllers();
        DisposeGameObjects();

        OnDispose();
    }

    private void DisposeBaseControllers()
    {
        if (_baseControllers == null)
        {
            return;
        }

        foreach (BaseController baseController in _baseControllers)
        {
            baseController.Dispose();
        }

        _baseControllers.Clear();
    }

    private void DisposeGameObjects()
    {
        if (_gameObjects == null)
        {
            return;
        }

        foreach (GameObject gameobject in _gameObjects)
        {
            Object.Destroy(gameobject);
        }

        _gameObjects.Clear();
    }

    protected virtual void OnDispose() { }

    protected void AddControllers(BaseController controller)
    {
        _baseControllers ??= new List<BaseController>();
        _baseControllers.Add(controller);
    }

    protected void AddGameObject(GameObject gameObject)
    {
        _gameObjects ??= new List<GameObject>();
        _gameObjects.Add(gameObject);
    }
}
