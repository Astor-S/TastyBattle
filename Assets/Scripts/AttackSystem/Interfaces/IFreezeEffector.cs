using UnityEngine;

namespace AttackSystem.Interfaces
{
    public interface IFreezeEffector
    {
        ParticleSystem PlayFreezeParticleEffect(Transform target);
    }
}