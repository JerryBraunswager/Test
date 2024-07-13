using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventoryObject : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _name;
    [SerializeField] private Button _button;

    public event Action<InventoryObject> ButtonClicked;
    public string Name => _name;

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickButton);
    }

    public void ShowCount(int count) 
    {
        if (count > 1)
        {
            _text.text = count.ToString();
        }
        else
        {
            _text.text = "";
        }
    }

    private void ClickButton()
    {
        ButtonClicked?.Invoke(this);
    }
}
