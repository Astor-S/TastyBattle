using UnityEngine;
using YG;

namespace UI.Screens
{
    public class AwardScreen : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void GiveReward()
        {
            if (YG2.saves.isMushroomCampaignCompleted == false)
            {
                gameObject.SetActive(true);
                YG2.saves.isMushroomCampaignCompleted = true;
                YG2.SaveProgress();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}