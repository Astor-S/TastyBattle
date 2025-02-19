using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private const float PauseScale = 0;
    private const float UnpauseScale = 1;

    public void Pause() => 
        Time.timeScale = PauseScale;

    public void Unpause() => 
        Time.timeScale = UnpauseScale;
}
