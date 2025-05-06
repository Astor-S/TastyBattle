using UnityEngine;
using YG;

public class LeaderboardHandler : MonoBehaviour
{
    public const string LeaderboardName = "Leaderboard";

    public void SetScore(int score)
    {
        if (score >= 0)
        {
            YG2.saves.Score += score;
            YG2.SetLeaderboard(LeaderboardName, YG2.saves.Score);
        }
    }
}
