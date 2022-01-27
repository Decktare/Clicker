using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;



public class HumansLeveUp : MonoBehaviour
{       
    public GameObject _human;
    public Transform _bHuman;
    public Transform _hParent; 
    public Score score;
    public int multiPlex = 2;

    public void OnClickCoins()
    {
        if(score.humansLevel < score.humansMaxLevel && score.coins >= score.humansCoinsPrice)
        {
            Instantiate(_human, _hParent, true);
            score.humansLevel++;           
            score.coins -= score.humansCoinsPrice;
            score.humansCoinsPrice *= multiPlex;
            score.humansDiamondsPrice *= multiPlex;
        }        
    }
    public void OnClickDiamons()
    {
        if(score.humansLevel < score.humansMaxLevel && score.diamonds >= score.humansDiamondsPrice)
        {
            Instantiate(_human, _hParent, true);
            score.humansLevel++;
            score.diamonds -= score.humansDiamondsPrice;
            score.humansCoinsPrice *= multiPlex;
            score.humansDiamondsPrice *= multiPlex;
        }
    }
}
