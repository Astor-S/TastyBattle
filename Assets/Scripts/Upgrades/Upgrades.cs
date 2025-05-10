using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private UpgradesData _playerUpgradesData;
    [SerializeField] private UpgradesData _enemyUpgradesData;

    public static Upgrades Instance { get; private set; } = null;

    public static UpgradesData Player => Instance._playerUpgradesData;
    public static UpgradesData Enemy => Instance._enemyUpgradesData;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
    }
}
