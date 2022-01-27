using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CityHallUpgrade : MonoBehaviour
{
    public GameObject _cityHall;
    public Score score;    
    public Sprite[] sprites = new Sprite[4];
    public int multiPlex = 2;

    public void OnClickCoins()
    {
        if (score.cityHallLevel < score.cityHallMaxLevel && score.coins >= score.cityHallCoinsPrice)
        {
            
            _cityHall.GetComponent<SpriteRenderer>().sprite = sprites[score.cityHallLevel];
            score.cityHallLevel++;
            score.coins -= score.cityHallCoinsPrice;
            score.cityHallCoinsPrice *= multiPlex;
            score.cityHallDiamondsPrice *= multiPlex;
        }
    }
    public void OnClickDiamons()
    {
        if (score.cityHallLevel < score.cityHallMaxLevel && score.diamonds >= score.cityHallDiamondsPrice)
        {
            score.cityHallLevel++;
            _cityHall.GetComponent<SpriteRenderer>().sprite = sprites[score.cityHallLevel];
            score.cityHallLevel++;
            score.diamonds -= score.cityHallDiamondsPrice;
            score.cityHallCoinsPrice *= multiPlex;
            score.cityHallDiamondsPrice *= multiPlex;
        }
    }
}
