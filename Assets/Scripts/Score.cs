using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Save
{
    public int coins;
    public int diamonds;

    public int humansLevel;
    public int humansCPrice;
    public int humansDPrice;

    public int wallLevel;
    public int wallCPrice;
    public int wallDPrice;

    public int cityHallLevel;
    public int cityHallCPrice;
    public int cityHallDPrice;

    public int castleLevel;
    public int castleCPrice;
    public int castleDPrice;

    public int churchLevel;
    public int churchCPrice;
    public int churchDPrice;

    public int barracksLevel;
    public int barracksCPrice;
    public int barracksDPrice;

    public int factoryLevel;
    public int factoryCPrice;
    public int factoryDPrice;

    public int[] date = new int[6];
}

public class Score : MonoBehaviour
{
    [Header("Экономика")]
    public int coins = 100000;
    public int diamonds = 1000;
    public int power = 0;
    private int addPoint = 1;
    private bool CheckTimer = true;
    [Header("Текстовый UI")]
    public Text scoreText;
    public Text diamondsText;
    public Text humansText;
    public Text powerText;
    [Header("Стена просчеты")]
    public int wallLevel = 1;
    public int wallMaxLevel = 10;
    public int wallDiamondsPrice = 10;
    public int wallCoinsPrice = 100;
    public Text wallCoinsButton;
    public Text wallDiamondsButton;
    [Header("Люди просчеты")]
    public int humansLevel = 1;
    public int humansMaxLevel = 500;
    public int humansDiamondsPrice = 10;
    public int humansCoinsPrice = 100;
    public Text humansCoinsButton;
    public Text humansDiamondsButton;
    [Header("Церковь просчеты")]
    public int churchLevel = 0;
    public int churchMaxLevel = 4;
    public int churchDiamondsPrice = 10;
    public int churchCoinsPrice = 100;
    public Text churchCoinsButton;
    public Text churchDiamondsButton;
    [Header("Капитолий просчеты")]
    public int cityHallLevel = 1;
    public int cityHallMaxLevel = 4;
    public int cityHallDiamondsPrice = 10;
    public int cityHallCoinsPrice = 100;
    public Text cityHallCoinsButton;
    public Text cityHallDiamondsButton;
    [Header("Производство просчеты")]
    public int factoryLevel = 0;
    public int factoryMaxLevel = 4;
    public int factoryDiamondsPrice = 10;
    public int factoryCoinsPrice = 100;
    public Text factoryCoinsButton;
    public Text factoryDiamondsButton;
    [Header("Замок просчеты")]
    public int castleLevel = 0;
    public int castleMaxLevel = 4;
    public int castleDiamondsPrice = 10;
    public int castleCoinsPrice = 100;
    public Text castleCoinsButton;
    public Text castleDiamondsButton;
    [Header("Казармы просчеты")]
    public int barracksLevel = 0;
    public int barracksMaxLevel = 4;
    public int barracksDiamondsPrice = 10;
    public int barracksCoinsPrice = 100;
    public Text barracksCoinsButton;
    public Text barracksDiamondsButton;

    [Header("Люди")]
    public GameObject _human;
    public Transform _hParent;

    [Header("Стена")]
    public GameObject _wall;
    public Sprite[] wall = new Sprite[11];

    [Header("Капитолий")]
    public GameObject _cityHall;
    public Sprite[] cityHall = new Sprite[4];

    [Header("Замок")]
    public GameObject _castle;
    public Sprite[] castle = new Sprite[4];

    [Header("Церковь")]
    public GameObject _church;
    public Sprite[] church = new Sprite[4];

    [Header("Казармы")]
    public GameObject _barracks;
    public Sprite[] barracks = new Sprite[4];

    [Header("Производство")]
    public GameObject _factory;
    public Sprite[] factory = new Sprite[4];

    private int humansCounterStart;
    private Save sv = new Save();
    private string path;

    public GameObject clickParent, clickTextPrefab;
    public Transform clickParentTransform;
    private ClickObj[] clickTextPool = new ClickObj[2];

    private string million = "M";    
    private int number;

    public int addedBonus = 0;

    public int[] factoryBonuses = new int[10];
    [Header("Боевая мощь")]
    public int[] wallP = new int[11];
    public int[] castleP = new int[11];
    public int[] barracksP = new int[11];
    public int[] cityHallP = new int[11];
    public int[] factoryP = new int[11];
    public int[] churchP = new int[11];
    public int[] humanP = new int[21];



    private void Awake ()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif

        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));

            coins = sv.coins;
            diamonds = sv.diamonds;

            DateTime dt = new DateTime(sv.date[0], sv.date[1], sv.date[2], sv.date[3], sv.date[4], sv.date[5]);
            TimeSpan ts = DateTime.Now - dt;
            addedBonus = Convert.ToInt32(ts.TotalSeconds);// / 20 * factoryLevel;

            if (sv.humansLevel > humansLevel)
            {
                humansCounterStart = sv.humansLevel - 1;
                while (humansCounterStart > 0)
                {
                    Instantiate(_human, _hParent, true);
                    humansCounterStart--;
                }
            }           

            humansLevel = sv.humansLevel;
            humansCoinsPrice = sv.humansCPrice;
            humansDiamondsPrice = sv.humansDPrice;

            if (sv.cityHallLevel > cityHallLevel)
            {
                _cityHall.SetActive(true);
                _cityHall.GetComponent<SpriteRenderer>().sprite = cityHall[sv.cityHallLevel-1];
            }
            cityHallLevel = sv.cityHallLevel;
            cityHallCoinsPrice = sv.cityHallCPrice;
            cityHallDiamondsPrice = sv.cityHallDPrice;
            
            if (sv.wallLevel > wallLevel)
            {
                _wall.SetActive(true);
                _wall.GetComponent<SpriteRenderer>().sprite = wall[sv.wallLevel];
            }
            wallLevel = sv.wallLevel;
            wallCoinsPrice = sv.wallCPrice;
            wallDiamondsPrice = sv.wallDPrice;

            if (sv.castleLevel > castleLevel)
            {
                _castle.SetActive(true);
                _castle.GetComponent<SpriteRenderer>().sprite = castle[sv.castleLevel-1];
            }
            castleLevel = sv.castleLevel;
            castleCoinsPrice = sv.castleCPrice;
            castleDiamondsPrice = sv.castleDPrice;

            if (sv.factoryLevel > factoryLevel)
            {
                _factory.SetActive(true);
                _factory.GetComponent<SpriteRenderer>().sprite = factory[sv.factoryLevel-1];
            }
            factoryLevel = sv.factoryLevel;
            factoryCoinsPrice = sv.factoryCPrice;
            factoryDiamondsPrice = sv.factoryDPrice;

            if (sv.churchLevel > churchLevel)
            {
                _church.SetActive(true);
                _church.GetComponent<SpriteRenderer>().sprite = church[sv.churchLevel-1];
            }
            churchLevel = sv.churchLevel;
            churchCoinsPrice = sv.churchCPrice;
            churchDiamondsPrice = sv.churchDPrice;

            if (sv.barracksLevel > barracksLevel)
            {
                _barracks.SetActive(true);
                _barracks.GetComponent<SpriteRenderer>().sprite = barracks[sv.barracksLevel-1];
            }
            barracksLevel = sv.barracksLevel;
            barracksCoinsPrice = sv.barracksCPrice;
            barracksDiamondsPrice = sv.barracksDPrice;
        }
    }

    void Start ()
    {
        for (int i = 0; i < clickTextPool.Length; i++)
        {
            clickTextPool[i] = Instantiate(clickTextPrefab, clickParent.transform).GetComponent<ClickObj>();
            //clickTextPool[i].SetActive(false);
        }
       
        StartCoroutine(BonusPerSec());            
    }

    public void PointAdd ()
    {
        if (CheckTimer)
        {            
            StartCoroutine(CheckTime());
        }        
    }

    void Update ()
    {        
        //-------------score
        humansText.text = "" + humansLevel;
        power = (cityHallP[cityHallLevel] + factoryP[factoryLevel] + churchP[churchLevel] + humanP[humansLevel]) * wallP[wallLevel] * castleP[castleLevel] * barracksP[barracksLevel];
        if (power > 999999)
        {
            number = power / 1000000;
            powerText.text = "" + number + million;
        }
        else
        {
            powerText.text = "" + power;
        }
        if (coins > 999999)
        {
            number = coins / 1000000;
            scoreText.text = "" + number + million;
        }
        else
        {
            scoreText.text = "" + coins;
        }
        //-------------
        if (diamonds > 999999)
        {
            number = diamonds / 1000000;
            diamondsText.text = "" + number + million;
        }
        else
        {
            diamondsText.text = "" + diamonds;
        }
        //-------------humans
        if (humansCoinsPrice > 999999)
        {
            number = humansCoinsPrice / 1000000;
            humansCoinsButton.text = "" + number + million;
        }
        else
        {
            humansCoinsButton.text = "" + humansCoinsPrice;
        }
        //-------------    
        if (humansDiamondsPrice > 999999)
        {
            number = humansDiamondsPrice / 1000000;
            humansDiamondsButton.text = "" + number + million;
        }
        else
        {
            humansDiamondsButton.text = "" + humansDiamondsPrice;
        }
        //-------------factory
        if (factoryCoinsPrice > 999999)
        {
            number = factoryCoinsPrice / 1000000;
            factoryCoinsButton.text = "" + number + million;
        }
        else
        {
            factoryCoinsButton.text = "" + factoryCoinsPrice;
        }
        //-------------
        if (factoryDiamondsPrice > 999999)
        {
            number = factoryDiamondsPrice / 1000000;
            factoryDiamondsButton.text = "" + number + million;
        }
        else
        {
            factoryDiamondsButton.text = "" + factoryDiamondsPrice;
        }
        //-------------wall
        if (wallCoinsPrice > 999999)
        {
            number = wallCoinsPrice / 1000000;
            wallCoinsButton.text = "" + number + million;
        }
        else
        {
            wallCoinsButton.text = "" + wallCoinsPrice;
        }
        //-------------
        if (wallDiamondsPrice > 999999)
        {
            number = wallDiamondsPrice / 1000000;
            wallDiamondsButton.text = "" + number + million;
        }
        else
        {
            wallDiamondsButton.text = "" + wallDiamondsPrice;
        }
        //-------------cityhall
        if (cityHallCoinsPrice > 999999)
        {
            number = cityHallCoinsPrice / 1000000;
            cityHallCoinsButton.text = "" + number + million;
        }
        else
        {
            cityHallCoinsButton.text = "" + cityHallCoinsPrice;
        }
        //-------------
        if (cityHallDiamondsPrice > 999999)
        {
            number = cityHallDiamondsPrice / 1000000;
            cityHallDiamondsButton.text = "" + number + million;
        }
        else
        {
            cityHallDiamondsButton.text = "" + cityHallDiamondsPrice;
        }
        //-------------castle
        if (castleCoinsPrice > 999999)
        {
            number = castleCoinsPrice / 1000000;
            castleCoinsButton.text = "" + number + million;
        }
        else
        {
            castleCoinsButton.text = "" + castleCoinsPrice;
        }
        //-------------
        if (castleDiamondsPrice > 999999)
        {
            number = castleDiamondsPrice / 1000000;
            castleDiamondsButton.text = "" + number + million;
        }
        else
        {
            castleDiamondsButton.text = "" + castleDiamondsPrice;
        }
        //-------------church
        if (churchCoinsPrice > 999999)
        {
            number = churchCoinsPrice / 1000000;
            churchCoinsButton.text = "" + number + million;
        }
        else
        {
            churchCoinsButton.text = "" + churchCoinsPrice;
        }
        //-------------
        if (churchDiamondsPrice > 999999)
        {
            number = churchDiamondsPrice / 1000000;
            churchDiamondsButton.text = "" + number + million;
        }
        else
        {
            churchDiamondsButton.text = "" + churchDiamondsPrice;
        }
        //-------------barracks
        if (barracksCoinsPrice > 999999)
        {
            number = barracksCoinsPrice / 1000000;
            barracksCoinsButton.text = "" + number + million;
        }
        else
        {
            barracksCoinsButton.text = "" + barracksCoinsPrice;
        }
        //-------------
        if (barracksDiamondsPrice > 999999)
        {
            number = barracksDiamondsPrice / 1000000;
            barracksDiamondsButton.text = "" + number + million;
        }
        else
        {
            barracksDiamondsButton.text = "" + barracksDiamondsPrice;
        }
        //-------------
        
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause (bool pause)
        {
            sv.coins = coins;
            sv.diamonds = diamonds;

            sv.cityHallLevel = cityHallLevel;
            sv.cityHallCPrice = cityHallCoinsPrice;
            sv.cityHallDPrice = cityHallDiamondsPrice;

            sv.humansLevel = humansLevel;
            sv.humansCPrice = humansCoinsPrice;
            sv.humansDPrice = humansDiamondsPrice;

            sv.wallLevel = wallLevel;
            sv.wallCPrice = wallCoinsPrice;
            sv.wallDPrice = wallDiamondsPrice;

            sv.castleLevel = castleLevel;
            sv.castleCPrice = castleCoinsPrice;
            sv.castleDPrice = castleDiamondsPrice;

            sv.factoryLevel = factoryLevel;
            sv.factoryCPrice = factoryCoinsPrice;
            sv.factoryDPrice = factoryDiamondsPrice;

            sv.churchLevel = churchLevel;
            sv.churchCPrice = churchCoinsPrice;
            sv.churchDPrice = churchDiamondsPrice;

            sv.barracksLevel = barracksLevel;
            sv.barracksCPrice = barracksCoinsPrice;
            sv.barracksDPrice = barracksDiamondsPrice;

            sv.date[0] = DateTime.Now.Year;
            sv.date[1] = DateTime.Now.Month;
            sv.date[2] = DateTime.Now.Day;
            sv.date[3] = DateTime.Now.Hour;
            sv.date[4] = DateTime.Now.Minute;
            sv.date[5] = DateTime.Now.Second;

            //PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
            if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
        }
#endif
    private void OnApplicationQuit ()
    {
        sv.coins = coins;
        sv.diamonds = diamonds;

        sv.cityHallLevel = cityHallLevel;
        sv.cityHallCPrice = cityHallCoinsPrice;
        sv.cityHallDPrice = cityHallDiamondsPrice;

        sv.humansLevel = humansLevel;
        sv.humansCPrice = humansCoinsPrice;
        sv.humansDPrice = humansDiamondsPrice;

        sv.wallLevel = wallLevel;
        sv.wallCPrice = wallCoinsPrice;
        sv.wallDPrice = wallDiamondsPrice;

        sv.castleLevel = castleLevel;
        sv.castleCPrice = castleCoinsPrice;
        sv.castleDPrice = castleDiamondsPrice;

        sv.factoryLevel = factoryLevel;
        sv.factoryCPrice = factoryCoinsPrice;
        sv.factoryDPrice = factoryDiamondsPrice;

        sv.churchLevel = churchLevel;
        sv.churchCPrice = churchCoinsPrice;
        sv.churchDPrice = churchDiamondsPrice;

        sv.barracksLevel = barracksLevel;
        sv.barracksCPrice = barracksCoinsPrice;
        sv.barracksDPrice = barracksDiamondsPrice;

        sv.date[0] = DateTime.Now.Year;
        sv.date[1] = DateTime.Now.Month;
        sv.date[2] = DateTime.Now.Day;
        sv.date[3] = DateTime.Now.Hour;
        sv.date[4] = DateTime.Now.Minute;
        sv.date[5] = DateTime.Now.Second;

        //PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }

    IEnumerator BonusPerSec()
    {
        while (true)
        {
            if (factoryLevel > 0)
            {
                if (addedBonus > 0)
                {
                    coins += (addedBonus / 20) * factoryBonuses[factoryLevel-1];
                    addedBonus = 0;
                }

                clickParentTransform.GetChild(1).gameObject.SetActive(true);
                clickTextPool[1].StartMotion(factoryBonuses[factoryLevel - 1]);
                coins += factoryBonuses[factoryLevel-1]; // Под экономику

                yield return new WaitForSeconds(1);
                clickParentTransform.GetChild(1).gameObject.SetActive(false);                
            }
            yield return new WaitForSeconds(20);
        }
        //Factory.factoryLevel;
    }
    IEnumerator CheckTime()
    {
        
        clickParentTransform.GetChild(0).gameObject.SetActive(true);
        
        coins += addPoint;
        clickTextPool[0].StartMotion(addPoint);
        CheckTimer = false;
        yield return new WaitForSeconds(1);
        
        clickParentTransform.GetChild(0).gameObject.SetActive(false);
        
        CheckTimer = true;
    }
}


