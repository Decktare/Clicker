using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ClickObj : MonoBehaviour
{
    private bool move;
    private Vector2 topVector;

    private void Update()
    {
        if (!move) return;
        transform.Translate(topVector * Time.deltaTime);
    }

    public void StartMotion(int scoreIncrease)
    {
        transform.localPosition = Vector2.zero;
        GetComponent<Text>().text = "+" + scoreIncrease;
        topVector = new Vector2(0, 2);
        move = true;        
    }
}
