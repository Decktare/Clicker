using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject _buttons;
    public GameObject _startPanel;
    public GameObject _topUI;
    public GameObject _objects;

    public void OnClick ()
    {
        _buttons.SetActive(true);
        _objects.SetActive(true);
        _topUI.SetActive(true);
        _startPanel.SetActive(false);
    }
}
