using StructureElements;
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

public class MVPPool<P, M>
    where P : Presenter
    where M : Transformable
{
    private Stack<P> _objects = new Stack<P>();

    private Func<M, P> _createFunc;
    private Action<P> _resetAction;

    public MVPPool(Func<M, P> createFunc, Action<P> resetAction = null)
    {
        _createFunc = createFunc;
        _resetAction = resetAction;
    }

    public void Release(P @object)
    {
        if (_resetAction != null)
            _resetAction(@object);

        _objects.Push(@object);
    }


    public P GetObject(M model)
    {
        if (_objects.Count == 0)
            return _createFunc(model);

        return _objects.Pop();
    }
}