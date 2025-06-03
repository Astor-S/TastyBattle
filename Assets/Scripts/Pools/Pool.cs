using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pools
{
    public class Pool<T>
        where T : MonoBehaviour
    {
        private readonly Stack<T> _objects = new ();
        private readonly Func<T> _createFunc;
        private readonly Action<T> _resetAction;

        public Pool(Func<T> createFunc, Action<T> resetAction = null)
        {
            _createFunc = createFunc;
            _resetAction = resetAction;
        }

        public void Release(T @object)
        {
            _resetAction?.Invoke(@object);
            _objects.Push(@object);
        }

        public T GetObject()
        {
            if (_objects.Count == 0)
                return _createFunc();

            return _objects.Pop();
        }
    }
}