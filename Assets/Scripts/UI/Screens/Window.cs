using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Close() =>
            gameObject.SetActive(false);

        public void Open() =>
            gameObject.SetActive(true);
    }
}