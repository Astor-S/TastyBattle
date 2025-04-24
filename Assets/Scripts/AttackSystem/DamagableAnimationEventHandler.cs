using System;
using UnityEngine;

public class DamagableAnimationEventHandler : MonoBehaviour
{
    public event Action Decayed;

    public void DeathEvent() =>
        Decayed?.Invoke();
}
