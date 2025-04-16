using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private Stack<T> _objects = new Stack<T>();

    private Func<T> _createFunc;
    private Action<T> _resetAction;

    public Pool(Func<T> createFunc, Action<T> resetAction = null)
    {
        _createFunc = createFunc;
        _resetAction = resetAction;
    }

    public void Release(T @object)
    {
        if (_resetAction != null)
            _resetAction(@object);

        _objects.Push(@object);
    }


    public T GetObject()
    {
        if (_objects.Count == 0)
           return _createFunc();

        return _objects.Pop();
    }
}