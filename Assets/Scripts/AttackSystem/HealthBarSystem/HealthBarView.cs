using UnityEngine;
using UnityEngine.UI;

namespace AttackSystem.HealthBarSystem
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private void LateUpdate()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                             Camera.main.transform.rotation * Vector3.up);
        }

        public void UpdateVisualHealth(float health, float maxHealth)
        {
            if (health == 0)
            {
                _slider.gameObject.SetActive(false);
            }
            else
            {
                _slider.value = health / maxHealth;
                _slider.gameObject.SetActive(true);
            }
        }
    }
}