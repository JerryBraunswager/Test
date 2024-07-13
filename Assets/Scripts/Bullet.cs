using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _damage;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector3 targetPosition, float damage)
    {
        _rigidbody.velocity = (targetPosition - transform.position).normalized;
        _damage = damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
