using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnter : MonoBehaviour
{
    public GameObject _buttons;
    public GameObject _shopPanel;
    public GameObject _topUI;
    public Transform _objects;    

    public void OnClick()
    {
        _buttons.SetActive(false);
        //_objects.SetActive(false);
        _topUI.SetActive(false);
        _shopPanel.SetActive(true);       
        
        for (int i = 0; i < _objects.childCount; i++)
        {
            _objects.GetChild(i).gameObject.SetActive(false);
        }
    }
}
