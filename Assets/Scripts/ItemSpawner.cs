using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<PickableItem> _items = new List<PickableItem>();

    public void SpawnItem(Vector3 position)
    {
        int number = Random.Range(0, _items.Count);

        var item = Instantiate(_items[number]);
        item.transform.position = position;
    }

    public IEnumerable<InventoryObject> Items()
    {
        foreach ( var item in _items ) 
        {
            yield return item.inventoryView;
        }
    }
}
