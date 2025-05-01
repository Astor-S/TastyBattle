using UnityEngine;
using UnityEngine.UI;

namespace AttackSystem.HealthBarSystem
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _healthColorImage;
        [SerializeField] private DamagableTarget _damagableTarget;

        private void OnEnable()
        {
            _damagableTarget.Health.ValueChanged += UpdateVisualHealth;
            UpdateVisualHealth(_damagableTarget.Health.Value, _damagableTarget.Health.MaxValue);
        }

        private void OnDisable() => 
            _damagableTarget.Health.ValueChanged -= UpdateVisualHealth;

        private void LateUpdate()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                             Camera.main.transform.rotation * Vector3.up);
        }

        public void SetColor(int layer)
        {
            if (layer == LayerMask.NameToLayer("Player"))
                _healthColorImage.color = Color.blue;
            else if (layer == LayerMask.NameToLayer("Enemy"))
                _healthColorImage.color = Color.red;
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