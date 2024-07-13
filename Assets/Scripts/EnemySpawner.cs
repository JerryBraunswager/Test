using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemSpawner))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Health prefab;

    private ItemSpawner _itemSpawner;

    private void Awake()
    {
        _itemSpawner = GetComponent<ItemSpawner>();
    }

    private void Start()
    {
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (prefab == null)
        {
            return;
        }

        var enemy = Instantiate(prefab, transform);
        Vector3 randomPoint = new(Random.Range(0f, 1f), Random.Range(0f, 1f));
        randomPoint.z = 10f;
        enemy.transform.position = Camera.main.ViewportToWorldPoint(randomPoint);
        enemy.Died += SpawnItem;
    }

    private void SpawnItem(Health health)
    {
        _itemSpawner.SpawnItem(health.transform.position);
        health.Died -= SpawnItem;
    }
}
