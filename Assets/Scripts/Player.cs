using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InventoryHandler _inventoryHandler;

    public void PickItem(InventoryObject inventoryObject)
    {
        _inventoryHandler.AddItem(inventoryObject);
    }
}
