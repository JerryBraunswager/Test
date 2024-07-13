using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private InventoryObject _inventoryView;

    public event Action<InventoryObject> Picked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Picked.Invoke(_inventoryView);
        Destroy(gameObject);
    }
}
