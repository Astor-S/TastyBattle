using System;
using System.Collections.Generic;
using StructureElements;

namespace Pools
{
    public class MVPPool<TPresenter, TTransformable>
        where TPresenter : Presenter
        where TTransformable : Transformable
    {
        private readonly Stack<TPresenter> _objects = new ();
        private readonly Func<TTransformable, TPresenter> _createFunc;
        private readonly Action<TPresenter> _resetAction;

        public MVPPool(Func<TTransformable, TPresenter> createFunc, Action<TPresenter> resetAction = null)
        {
            _createFunc = createFunc;
            _resetAction = resetAction;
        }

        public void Release(TPresenter @object)
        {
            _resetAction?.Invoke(@object);
            _objects.Push(@object);
        }

        public TPresenter GetObject(TTransformable model)
        {
            if (_objects.Count == 0)
                return _createFunc(model);

            return _objects.Pop();
        }
    }
}