using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallUpdate : MonoBehaviour
{
    public GameObject _wall;
    public Score score;
    public Sprite[] sprites = new Sprite[11];
    public int multiPlex = 2;

    public void OnClickCoins()
    {
        if (score.wallLevel < score.wallMaxLevel && score.coins >= score.wallCoinsPrice && score.cityHallLevel > score.wallLevel)
        {
            score.wallLevel++;
            _wall.GetComponent<SpriteRenderer>().sprite = sprites[score.wallLevel];            
            score.coins -= score.wallCoinsPrice;
            score.wallCoinsPrice *= multiPlex;
            score.wallDiamondsPrice *= multiPlex;
        }
    }
    public void OnClickDiamons()
    {
        if (score.wallLevel < score.wallMaxLevel && score.diamonds >= score.wallDiamondsPrice && score.cityHallLevel > score.wallLevel)
        {
            score.wallLevel++;
            _wall.GetComponent<SpriteRenderer>().sprite = sprites[score.wallLevel];            
            score.diamonds -= score.wallDiamondsPrice;
            score.wallCoinsPrice *= multiPlex;
            score.wallDiamondsPrice *= multiPlex;
        }
    }
}
