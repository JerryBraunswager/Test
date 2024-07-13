using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private ItemSpawner _itemSpawner;
    [SerializeField] private Transform _inventoryContent;
    [SerializeField] private ButtonDeleteView _button;

    private List<InventoryObject> _inventoryObjects = new List<InventoryObject>();
    private List<InventoryObject> _spawnedObjects = new List<InventoryObject>();

    private void Start()
    {
        _spawnedObjects.Clear();

        foreach(var item in _itemSpawner.Items())
        {
            _spawnedObjects.Add(Instantiate(item, _inventoryContent));
            item.gameObject.SetActive(false);
        }
    }

    public void AddItem(InventoryObject inventoryObject)
    {
        _inventoryObjects.Add(inventoryObject);
        ViewInventory();
    }

    public void ViewInventory()
    {
        ClearInventory();
        List<InventoryObject> objects = _inventoryObjects.Distinct().ToList();

        for(int i = 0; i < objects.Count; i++) 
        {
            foreach (InventoryObject spawnedObjects in _spawnedObjects)
            {
                if (objects[i].Name == spawnedObjects.Name)
                {
                    spawnedObjects.ShowCount(_inventoryObjects.Count(n => n.Name == objects[i].Name));
                    spawnedObjects.transform.SetSiblingIndex(i);
                    spawnedObjects.transform.gameObject.SetActive(true);
                    spawnedObjects.ButtonClicked += ItemClick;
                }
            }
        }
    }

    private void ClearInventory()
    {
        foreach(InventoryObject inventoryObject in _spawnedObjects) 
        {
            inventoryObject.gameObject.SetActive(false);
            inventoryObject.ButtonClicked -= ItemClick;
        }
    }

    public bool HasBullets()
    {
        return Check("Bullets");
    }

    public bool HasAK()
    {
        return Check("AK-74");
    }

    public void TakeBullet()
    {
        foreach(InventoryObject item in _inventoryObjects) 
        { 
            if(item.Name == "Bullets")
            {
                _inventoryObjects.Remove(item);
                break;
            }
        }
    }

    public void DeleteItem(InventoryObject item)
    {
        for(int i = 0;  i < _inventoryObjects.Count; i++)
        {
            if(item.Name == _inventoryObjects[i].Name) 
            { 
                _inventoryObjects.RemoveAt(i);
                ViewInventory();
            }
        }
    }

    private void ItemClick(InventoryObject item)
    {
        _button.ShowButton(item);
    }

    private bool Check(string name)
    {
        foreach (InventoryObject item in _inventoryObjects)
        {
            if (item.Name == name)
            {
                return true;
            }
        }

        return false;
    }
}
