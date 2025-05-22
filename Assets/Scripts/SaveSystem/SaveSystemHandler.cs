using UnityEngine;
using YG;

public class SaveSystemHandler : MonoBehaviour
{
    [SerializeField] private SaveSystem[] _saveSystems;

    private void Start()
    {
        //if (YG2.player.auth)
        //    foreach (SaveSystem saveSystem in _saveSystems)
        //        saveSystem.Load();
        //else
            foreach (SaveSystem saveSystem in _saveSystems)
                saveSystem.LoadLocal();        
    }

    private void OnDisable()
    {
        foreach (SaveSystem saveSystem in _saveSystems)
            saveSystem.Save();
    }

    private void OnApplicationQuit()
    {
        foreach (SaveSystem saveSystem in _saveSystems)
            saveSystem.Save();
    }
}
