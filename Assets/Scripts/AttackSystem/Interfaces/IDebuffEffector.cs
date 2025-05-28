using UnityEngine;

namespace AttackSystem.Interfaces
{
    public interface IDebuffEffector
    {
        ParticleSystem PlayDebuffParticleEffect(Transform target);
    }
}