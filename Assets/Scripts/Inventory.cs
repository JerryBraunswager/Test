using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private void Start()
    {
        transform.gameObject.SetActive(false);
    }

    public void ClickButton()
    {
        transform.gameObject.SetActive(!transform.gameObject.activeSelf);
    }
}
