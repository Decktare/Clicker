using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CastleBuildAndUpdate : MonoBehaviour
{
    public GameObject _castle;
    public Score score;    
    public Sprite[] sprites = new Sprite[4];
    private int startBuildStatus = 0;
    public int multiPlex = 2;


    public void OnClickCoins()
    {
        if (score.castleLevel < score.castleMaxLevel && score.castleLevel > startBuildStatus && score.coins >= score.castleCoinsPrice && score.cityHallLevel > score.castleLevel)
        {
            _castle.GetComponent<SpriteRenderer>().sprite = sprites[score.castleLevel];
            score.castleLevel++;
            score.coins -= score.castleCoinsPrice;
            score.castleCoinsPrice *= multiPlex;
            score.castleDiamondsPrice *= multiPlex;
        }
        if (score.castleLevel == startBuildStatus && score.coins >= score.castleCoinsPrice)
        {
            score.castleLevel++;
            score.coins -= score.castleCoinsPrice;
            score.castleCoinsPrice *= multiPlex;
            score.castleDiamondsPrice *= multiPlex;

            _castle.SetActive(true);
        }
    }
    public void OnClickDiamons()
    {
        if (score.castleLevel < score.castleMaxLevel && score.castleLevel > startBuildStatus && score.diamonds >= score.castleDiamondsPrice && score.cityHallLevel > score.castleLevel)
        {
            score.castleLevel++;
            score.diamonds -= score.castleDiamondsPrice;
            score.castleCoinsPrice *= multiPlex;
            score.castleDiamondsPrice *= multiPlex;

            _castle.GetComponent<SpriteRenderer>().sprite = sprites[score.castleLevel];
        }
        if (score.castleLevel == startBuildStatus && score.diamonds >= score.castleDiamondsPrice)
        {
            score.castleLevel++;
            score.diamonds -= score.castleDiamondsPrice;
            score.castleCoinsPrice *= multiPlex;
            score.castleDiamondsPrice *= multiPlex;

            _castle.SetActive(true);
        }
    }
}
