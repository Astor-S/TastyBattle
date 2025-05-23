using UnityEngine;

public struct LayersData
{
    public const string Player = nameof(Player);
    public const string Enemy = nameof(Enemy);

    public static int PlayerLayerNumber => LayerMask.NameToLayer(Player);
    public static int EnemyLayerNumber => LayerMask.NameToLayer(Enemy);
}