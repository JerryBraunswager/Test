using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _damage;

    public string Name => _name;
    public Transform ShootPoint => _shootPoint;
    public float Damage => _damage;
}
