using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private InventoryObject _inventoryView;

    public InventoryObject inventoryView => _inventoryView;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.PickItem(_inventoryView);
            Destroy(gameObject);
        }
    }
}
