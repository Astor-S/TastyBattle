using UnityEngine;

public class DamagableAnimationEventHandler : MonoBehaviour
{
    public void DeathEvent() =>
        Destroy(gameObject);
}
