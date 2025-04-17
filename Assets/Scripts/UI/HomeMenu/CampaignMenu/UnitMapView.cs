using UnityEngine;

public class UnitMapView : MonoBehaviour
{
    [SerializeField] private string _description;

    public string Description => _description;
}