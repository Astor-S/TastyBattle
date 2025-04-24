using System;
using UnityEngine;

namespace StructureElements
{
    public class View : MonoBehaviour
    {
        public event Action WalkingStarted;
        public event Action Dead;

        protected void StartWalking() => 
            WalkingStarted?.Invoke();

        protected void StartDeathSound() => 
            Dead?.Invoke();
    }
}
