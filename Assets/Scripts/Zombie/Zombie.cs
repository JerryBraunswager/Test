using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private DamageZombie _damageCollider;
    [SerializeField] private NoticeZombie _noticeCollider;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _noticeCollider.Saw += SeePlayer;
        _damageCollider.CausedDamage += DamagePlayer;
    }

    private void OnDisable()
    {
        _noticeCollider.Saw -= SeePlayer;
        _damageCollider.CausedDamage -= DamagePlayer;
    }

    private void DamagePlayer(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage * Time.deltaTime);
        }
    }

    private void SeePlayer(Collider2D collision)
    {
        Vector3 direction = (collision.transform.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
