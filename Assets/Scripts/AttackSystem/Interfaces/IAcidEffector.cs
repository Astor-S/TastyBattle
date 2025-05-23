using UnityEngine;

namespace AttackSystem.Interfaces
{
    public interface IAcidEffector
    {
        ParticleSystem PlayAcidParticleEffect(Transform target);
    }
}