using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChurchBuildAndUpgrade : MonoBehaviour
{
    public GameObject _church;
    public Score score;
    public Sprite[] sprites = new Sprite[4];
    private int startBuildStatus = 0;
    public int multiPlex = 2;

    public void OnClickCoins()
    {
        if (score.churchLevel < score.churchMaxLevel && score.churchLevel > startBuildStatus && score.coins >= score.churchCoinsPrice && score.cityHallLevel > score.churchLevel)
        {
            _church.GetComponent<SpriteRenderer>().sprite = sprites[score.churchLevel];
            score.churchLevel++;
            score.coins -= score.churchCoinsPrice;
            score.churchCoinsPrice *= multiPlex;
            score.churchDiamondsPrice *= multiPlex;
        }
        if (score.churchLevel == startBuildStatus && score.coins >= score.churchCoinsPrice)
        {
            score.churchLevel++;
            score.coins -= score.churchCoinsPrice;
            score.churchCoinsPrice *= multiPlex;
            score.churchDiamondsPrice *= multiPlex;

            _church.SetActive(true);
        }
    }
    public void OnClickDiamons()
    {
        if (score.churchLevel < score.churchMaxLevel && score.churchLevel > startBuildStatus && score.diamonds >= score.churchDiamondsPrice && score.cityHallLevel > score.churchLevel)
        {
            score.churchLevel++;
            score.diamonds -= score.churchDiamondsPrice;
            score.churchCoinsPrice *= multiPlex;
            score.churchDiamondsPrice *= multiPlex;

            _church.GetComponent<SpriteRenderer>().sprite = sprites[score.churchLevel];
        }
        if (score.churchLevel == startBuildStatus && score.diamonds >= score.churchDiamondsPrice)
        {
            score.churchLevel++;
            score.diamonds -= score.churchDiamondsPrice;
            score.churchCoinsPrice *= multiPlex;
            score.churchDiamondsPrice *= multiPlex;

            _church.SetActive(true);
        }
    }
}
