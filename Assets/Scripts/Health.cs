using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _current;

    private void Start()
    {
        _current = _maxValue;
        HealthCheck();
    }

    public event UnityAction<float, float> HealthChanged;
    public event UnityAction Died;

    public void TakeDamage(float damage) 
    {
        if(damage > 0) 
        {
            _current -= damage;
            HealthCheck();

            if(_current == 0)
            {
                Died.Invoke();
            }
        }
    }

    private void HealthCheck()
    {
        _current = Mathf.Clamp(_current, 0, _maxValue);
        HealthChanged.Invoke(_current, _maxValue);
    }
}
