using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeZombie : MonoBehaviour
{
    public event Action<Collider2D> Saw;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Saw?.Invoke(collision);
    }
}
