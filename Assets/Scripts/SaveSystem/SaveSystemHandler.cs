using UnityEngine;
using YG;

public class SaveSystemHandler : MonoBehaviour
{
    [SerializeField] private SaveSystem[] _saveSystems;

    private void Start()
    {
       foreach (SaveSystem saveSystem in _saveSystems) 
            saveSystem.Load();

       //if(YG2.player.auth)
       // {
       //     saveSystem.Load();
       // }
       //else
       // {
       //     saveSystem.Load(); // םמ ס  ןנופסמג
       // }
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
