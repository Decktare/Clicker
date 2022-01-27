using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopExit : MonoBehaviour
{
    public GameObject _buttons;
    public GameObject _shopPanel;
    public GameObject _topUI;
    public Transform _objects;    

    public void OnClick()
    {
        _buttons.SetActive(true);
        //_objects.SetActive(true);
        _topUI.SetActive(true);
        _shopPanel.SetActive(false);

        for (int i = 0; i < _objects.childCount; i++)
        {
            _objects.GetChild(i).gameObject.SetActive(true);
        }
    }
}
