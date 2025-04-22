using UnityEngine;

public class UnitModelView : MonoBehaviour
{
    [SerializeField] private string _description;

    public string Description => _description;
}