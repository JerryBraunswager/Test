using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDeleteView : MonoBehaviour
{
    public void ShowButton()
    {
        gameObject.SetActive(true);
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }
}
