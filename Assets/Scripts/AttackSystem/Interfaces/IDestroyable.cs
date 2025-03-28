using System;

namespace AttackSystem.Interfaces
{
    public interface IDestroyable<T> where T : IDestroyable<T>
    {
        public event Action<T> Destroyed;
    }
}