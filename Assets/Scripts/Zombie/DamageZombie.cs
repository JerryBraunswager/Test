using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZombie : MonoBehaviour
{
    public event Action<Collider2D> CausedDamage;
    private void OnTriggerStay2D(Collider2D collision)
    {
        CausedDamage?.Invoke(collision);
    }
}
