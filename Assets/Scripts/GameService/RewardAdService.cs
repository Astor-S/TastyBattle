using System;
using UnityEngine;
using YG;

namespace GameService
{
    public class RewardAdService : MonoBehaviour
    {
        public event Action CoinsReceived;
        public event Action DoubleCoinsReceived;
        public event Action SkinReceived;
        public event Action CampaignReceived;
        public event Action EmergencyReceived;

        public string CampaignId { get; private set; } = "campaign";
        public string CoinsId { get; private set; } = "coins";
        public string DoubleCoinsId { get; private set; } = "double coins";
        public string SkinId { get; private set; } = "skin";
        public string EmergencyId { get; private set; } = "emergency";

        private void OnEnable() =>
            YG2.onRewardAdv += Reward;

        private void OnDisable() =>
            YG2.onRewardAdv -= Reward;

        public void ShowRewardAd(string id) =>
            YG2.RewardedAdvShow(id);

        private void Reward(string id)
        {
            switch (id)
            {
                case var _ when id == CoinsId:
                    CoinsReceived?.Invoke();
                    break;

                case var _ when id == DoubleCoinsId:
                    DoubleCoinsReceived?.Invoke();
                    break;

                case var _ when id == SkinId:
                    SkinReceived?.Invoke();
                    break;

                case var _ when id == CampaignId:
                    CampaignReceived?.Invoke();
                    break;

                case var _ when id == EmergencyId:
                    EmergencyReceived?.Invoke();
                    break;
            }
        }
    }
}