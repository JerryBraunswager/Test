using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _healthSlider;
    private float _targetSliderValue;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= DisplayHealth;
    }

    private void Update()
    {
        if(_healthSlider.value != _targetSliderValue)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, _targetSliderValue, Time.deltaTime);
        }
    }

    private void DisplayHealth(float currentHealth, float maxHeath)
    {
        _targetSliderValue = currentHealth / maxHeath;
    }
}
