using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDeleteView : MonoBehaviour
{
    [SerializeField] private InventoryHandler _inventoryHandler;
    private InventoryObject _toDelete;

    public void ShowButton(InventoryObject item)
    {
        gameObject.SetActive(true);
        _toDelete = item;
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }

    public void DeleteItem()
    {
        _inventoryHandler.DeleteItem(_toDelete);
        _toDelete = null;
    }
}
