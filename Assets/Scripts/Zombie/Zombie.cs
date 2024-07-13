using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private DamageZombie _damageCollider;
    [SerializeField] private NoticeZombie _noticeCollider;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

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
        _rigidbody.velocity = Vector3.MoveTowards(transform.position, collision.transform.position, _speed * Time.deltaTime).normalized * _speed * Time.deltaTime;
    }
}
