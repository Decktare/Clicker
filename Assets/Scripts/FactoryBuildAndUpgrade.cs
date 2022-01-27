using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryBuildAndUpgrade : MonoBehaviour
{
    public GameObject _factory;
    public Score score;    
    public Sprite[] sprites = new Sprite[4];
    private int startBuildStatus = 0;
    public int multiPlex = 2;     

    public void OnClickCoins()
    {
        if (score.factoryLevel < score.factoryMaxLevel && score.factoryLevel > startBuildStatus && score.coins >= score.factoryCoinsPrice && score.cityHallLevel > score.factoryLevel)
        {
            _factory.GetComponent<SpriteRenderer>().sprite = sprites[score.factoryLevel];
            score.factoryLevel++;
            score.coins -= score.factoryCoinsPrice;
            score.factoryCoinsPrice *= multiPlex;
            score.factoryDiamondsPrice *= multiPlex;            
        }
        if (score.factoryLevel == startBuildStatus && score.coins >= score.factoryCoinsPrice)
        {
            score.factoryLevel++;
            score.coins -= score.factoryCoinsPrice;
            score.factoryCoinsPrice *= multiPlex;
            score.factoryDiamondsPrice *= multiPlex;

            _factory.SetActive(true);
        }
    }
    public void OnClickDiamons()
    {
        if (score.factoryLevel < score.factoryMaxLevel && score.factoryLevel > startBuildStatus && score.diamonds >= score.factoryDiamondsPrice && score.cityHallLevel > score.factoryLevel)
        {
            score.factoryLevel++;
            score.diamonds -= score.factoryDiamondsPrice;
            score.factoryCoinsPrice *= multiPlex;
            score.factoryDiamondsPrice *= multiPlex;

            _factory.GetComponent<SpriteRenderer>().sprite = sprites[score.factoryLevel];
        }
        if (score.factoryLevel == startBuildStatus && score.diamonds >= score.factoryDiamondsPrice)
        {
            score.factoryLevel++;
            score.diamonds -= score.factoryDiamondsPrice;
            score.factoryCoinsPrice *= multiPlex;
            score.factoryDiamondsPrice *= multiPlex;

            _factory.SetActive(true);
        }
    }
}
