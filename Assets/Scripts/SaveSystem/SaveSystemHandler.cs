using UnityEngine;

public class SaveSystemHandler : MonoBehaviour
{
    [SerializeField] private SaveSystem[] _saveSystems;

    private void Start()
    {
       foreach (SaveSystem saveSystem in _saveSystems) 
            saveSystem.Load();
    }

    private void OnDisable()
    {
        foreach (SaveSystem saveSystem in _saveSystems)
            saveSystem.Save();
    }
}
