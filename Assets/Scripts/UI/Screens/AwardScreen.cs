using UnityEngine;

namespace UI.Screens
{
    public class AwardScreen : MonoBehaviour
    {
        //[SerializeField] private Skins _skinToAdd;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void GiveReward()
        {
            //if (_savesYG.ownedSkins.Contains(_skinToAdd) == false)
            //{
            //    gameObject.SetActive(true);
            //    _savesYG.ownedSkins.Add(_skinToAdd);
            //    YandexGame.SaveProgress();
            //}
            //else
            //{
            //    gameObject.SetActive(false);
            //}
        }
    }
}