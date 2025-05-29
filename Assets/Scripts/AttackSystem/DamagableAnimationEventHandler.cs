using System;
using UnityEngine;

namespace AttackSystem
{
    public class DamagableAnimationEventHandler : MonoBehaviour
    {
        public event Action Decayed;

        public void DeathEvent() =>
            Decayed?.Invoke();
    }
}
