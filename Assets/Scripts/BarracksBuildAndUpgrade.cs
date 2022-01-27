using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarracksBuildAndUpgrade : MonoBehaviour
{
    public GameObject _barracks;
    public Score score;
    public Sprite[] sprites = new Sprite[4];
    private int startBuildStatus = 0;
    public int multiPlex = 2;

    public void OnClickCoins()
    {
        if (score.barracksLevel < score.barracksMaxLevel && score.barracksLevel > startBuildStatus && score.coins >= score.barracksCoinsPrice && score.cityHallLevel > score.barracksLevel)
        {
            _barracks.GetComponent<SpriteRenderer>().sprite = sprites[score.barracksLevel];
            score.barracksLevel++;
            score.coins -= score.barracksCoinsPrice;
            score.barracksCoinsPrice *= multiPlex;
            score.barracksDiamondsPrice *= multiPlex;
        }
        if (score.barracksLevel == startBuildStatus && score.coins >= score.barracksCoinsPrice)
        {
            score.barracksLevel++;
            score.coins -= score.barracksCoinsPrice;
            score.barracksCoinsPrice *= multiPlex;
            score.barracksDiamondsPrice *= multiPlex;

            _barracks.SetActive(true);
        }
    }
    public void OnClickDiamons()
    {
        if (score.barracksLevel < score.barracksMaxLevel && score.barracksLevel > startBuildStatus && score.diamonds >= score.barracksDiamondsPrice && score.cityHallLevel > score.barracksLevel)
        {
            score.barracksLevel++;
            score.diamonds -= score.barracksDiamondsPrice;
            score.barracksCoinsPrice *= multiPlex;
            score.barracksDiamondsPrice *= multiPlex;

            _barracks.GetComponent<SpriteRenderer>().sprite = sprites[score.barracksLevel];
        }
        if (score.barracksLevel == startBuildStatus && score.diamonds >= score.barracksDiamondsPrice)
        {
            score.barracksLevel++;
            score.diamonds -= score.barracksDiamondsPrice;
            score.barracksCoinsPrice *= multiPlex;
            score.barracksDiamondsPrice *= multiPlex;

            _barracks.SetActive(true);
        }
    }
}
