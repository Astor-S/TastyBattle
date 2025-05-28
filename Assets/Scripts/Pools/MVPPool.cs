using System;
using System.Collections.Generic;
using StructureElements;

namespace Pools
{
    public class MVPPool<P, M>
        where P : Presenter
        where M : Transformable
    {
        private readonly Stack<P> _objects = new();
        private readonly Func<M, P> _createFunc;
        private readonly Action<P> _resetAction;

        public MVPPool(Func<M, P> createFunc, Action<P> resetAction = null)
        {
            _createFunc = createFunc;
            _resetAction = resetAction;
        }

        public void Release(P @object)
        {
            _resetAction?.Invoke(@object);
            _objects.Push(@object);
        }

        public P GetObject(M model)
        {
            if (_objects.Count == 0)
                return _createFunc(model);

            return _objects.Pop();
        }
    }
}