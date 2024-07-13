using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Weapon _defaultWeapon;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private InventoryHandler _inventoryHandler;

    private List<Weapon> _weaponList = new List<Weapon>();
    private Zombie _target;

    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++) 
        { 
            if(transform.GetChild(i).TryGetComponent(out Weapon weapon))
            {
                _weaponList.Add(weapon);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Zombie zombie))
        {
            if(_target == null)
            {
                _target = zombie;
            }
        }
    }

    public void ClickShoot()
    {
        if(_target == null)
        {  
            return;
        }

        Weapon weapon = ChooseWeapon();
        Bullet newBullet = Instantiate(_prefab);
        newBullet.transform.position = weapon.ShootPoint.position;
        newBullet.Init(_target.transform.position, weapon.Damage);
    }

    private Weapon ChooseWeapon()
    {
        AllHide();

        if (_inventoryHandler.HasAK())
        {
            if (_inventoryHandler.HasBullets())
            {
                foreach(Weapon weapon in _weaponList) 
                {
                    if(weapon.Name == "AK-74")
                    {
                        weapon.transform.gameObject.SetActive(true);
                        _inventoryHandler.TakeBullet();
                        return weapon;
                    }
                }
            }
        }

        return ShowDefaultWeapon();
    }

    private void AllHide()
    {
        foreach(Weapon weapon in _weaponList) 
        { 
            weapon.transform.gameObject.SetActive(false);
        }
    }

    private Weapon ShowDefaultWeapon()
    {
        _defaultWeapon.transform.gameObject.SetActive(true);
        return _defaultWeapon;
    }
}
