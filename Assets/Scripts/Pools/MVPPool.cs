using StructureElements;
using System;
using System.Collections.Generic;

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