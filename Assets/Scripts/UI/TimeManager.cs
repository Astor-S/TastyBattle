using UnityEngine;
using YG;

public class TimeManager : MonoBehaviour
{
    private const float PauseScale = 0;
    private const float UnpauseScale = 1;

    public static void Pause()
    {
        Time.timeScale = PauseScale;
        YG2.GameplayStop();
    }

    public static void Unpause()
    {
        Time.timeScale = UnpauseScale;
        YG2.GameplayStart();
    }
}
