using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class GamePlay : MonoBehaviour
{
    public static GamePlay Instance;

    [SerializeField]
    GameObject enemyClone;
    int level;
    // [SerializeField]
    // GameObject[] knifeOfHandObject;

    [SerializeField]
    GameObject uiGameOver;
    [SerializeField]
    GameObject uiSetting;
    [SerializeField]
    GameObject uiPlayObject;

    [SerializeField]
    GameObject[] uiItem;

    [SerializeField]
    TextMeshProUGUI uiTMPStageOver;
    [SerializeField]
    TextMeshProUGUI uiTMPStagePlay;
    [SerializeField]
    TextMeshProUGUI uiTMPApple;


    //Max Knife va number Knife
    [SerializeField]
    int maxKnife;
    [SerializeField]
    RawImage itemKnife;
    [SerializeField]
    Sprite WhiteItem;
    [SerializeField]
    Sprite blackItem;

    int numberKnife, knifeThrowed;
    int appleScore, selectItem;
    bool isGameOver, hasSoundApple, isContinuePlay,isShowIAds, isShowRewardAds;


    private void Awake()
    {

        if (Instance == null)
            Instance = this;

        level = 1;
        numberKnife = 0;
        //so knife hand da~ nem": knife trung" enemy, ko trung" enemy va ca knife nem ra sau khi game over
        knifeThrowed = 0;
        maxKnife = 7;
        //true la dummy, false la fruit
        isGameOver = false;
        isContinuePlay = false;
         appleScore = LoadingScene.appleScore;
        selectItem = LoadingScene.selectItem;
        UpdateShowAppleScore(appleScore);
        uiTMPApple.SetText("" + appleScore);

        // true la co an dc apple nen co sound apple, 
        hasSoundApple = false;
        isShowIAds = false;
        isShowRewardAds = false;
    }


    void InstanceListItem(int maxK)
    {
        for(int i = 0; i < maxK; i++)
        {
            uiItem[i].SetActive(true);
            uiItem[i].GetComponent<Image>().sprite = WhiteItem;
        }
        if(maxK<17)
        for(int j = maxK; j < 17; j++)
        {
                uiItem[j].SetActive(false);
        }

    }

  
    public int SelectItem
    {
        get => selectItem;
        set => selectItem = value;
    }


    void UpdateShowAppleScore(int score)
    {
        if (appleScore < 10)
        {
            uiTMPApple.rectTransform.anchoredPosition = new Vector2(-329f, -52f);
        }
        else if (appleScore < 100)
        {
            uiTMPApple.rectTransform.anchoredPosition = new Vector2(-343f, -52f);
        }
        else if (appleScore < 1000)
        {
            uiTMPApple.rectTransform.anchoredPosition = new Vector2(-357f, -52f);
        }
        else if (appleScore < 10000)
        {
            uiTMPApple.rectTransform.anchoredPosition = new Vector2(-371f, -52f);
        }
        else if (appleScore < 100000)
        {
            uiTMPApple.rectTransform.anchoredPosition = new Vector2(-385f, -52f);
        }
        else
        {
            uiTMPApple.rectTransform.anchoredPosition = new Vector2(-399f, -52f);
        }
    }


    void Start()
    {

        Invoke("LoadLv" + level, 0.001f);

        // loadLv1();
    }


    public void SetSoundAOrE(bool s)
    {
        hasSoundApple = s;
    }

    public bool GetSoundAOrE()
    {
        return hasSoundApple;
    }

    public void AddApple(int num)
    {
        appleScore += num;
        if (appleScore % 10 == 0)
        {
            UpdateShowAppleScore(appleScore);
        }
        uiTMPApple.SetText("" + appleScore);
    }
    public int GetApple()
    {
        return appleScore;
    }

    public void SetApple(int sc)
    {
        appleScore = sc;
        PlayerPrefs.SetInt("apple", sc);
    }
    public int getMaxKnife()
    {
        return maxKnife;
    }
    public void AddNumberKnife()
    {
        knifeThrowed += 1;
        this.numberKnife += 1;
        if(maxKnife-numberKnife>-1)
        uiItem[(maxKnife - numberKnife)].GetComponent<Image>().sprite = blackItem;
    }
    public void SetNumberKnife(int numberKnife)
    {
        this.numberKnife = numberKnife;
    }
    public int GetNumberKnife()
    {
        return numberKnife;
    }

    public GameObject getEnemyObject()
    {
        return enemyClone;
    }


    public void InstanceGame()
    {
        numberKnife = 0;
        enemyClone.SetActive(true);
        Hand.Instance.ShowKnifeOfHand();
        isGameOver = false;
        uiTMPStagePlay.SetText("STAGE " + level);
        InstanceListItem(maxKnife);
    }



    public void LoadLv1()
    {
        maxKnife = 7;
        InstanceGame();
        LevelManager.Instance.LoadLv(1);
        EnemyRotate.Instance.loadLV1();

    }

    public void LoadLv2()

    {
        maxKnife = 8;
        InstanceGame();
        LevelManager.Instance.LoadLv(2);
        EnemyRotate.Instance.loadLV2();
    }

    public void LoadLv3()
    {
        maxKnife = 10;
        InstanceGame();
        LevelManager.Instance.LoadLv(3);
        EnemyRotate.Instance.loadLV3();


    }

    public void LoadLv4()
    {
        maxKnife = 9;
        InstanceGame();
        LevelManager.Instance.LoadLv(4);
        EnemyRotate.Instance.loadLV4();


    }

    public void LoadLv5()
    {
        maxKnife = 13;
        InstanceGame();
        LevelManager.Instance.LoadLv(5);
        EnemyRotate.Instance.loadLV5();

    }

    public void LoadLv6()
    {
        maxKnife = 10;
        InstanceGame();

        LevelManager.Instance.LoadLv(6);
        EnemyRotate.Instance.loadLV6();


    }

    public void LoadLv7()
    {
        maxKnife = 11;
        InstanceGame();
        LevelManager.Instance.LoadLv(7);
        EnemyRotate.Instance.loadLV7();

    }
    public void LoadLv8()
    {
        maxKnife = 9;
        InstanceGame();
        LevelManager.Instance.LoadLv(8);
        EnemyRotate.Instance.loadLV8();

    }

    public void LoadLv9()
    {
        maxKnife = 11;
        InstanceGame();
        LevelManager.Instance.LoadLv(9);
        EnemyRotate.Instance.loadLV9();

    }

    public void LoadLv10()
    {
        maxKnife = 13;
        InstanceGame();
        LevelManager.Instance.LoadLv(10);
        EnemyRotate.Instance.loadLV10();

    }

    public void LoadLv11()
    {
        maxKnife = 10;
        InstanceGame();
        LevelManager.Instance.LoadLv(11);
        EnemyRotate.Instance.loadLV11();

    }
    public void LoadLv12()
    {
        maxKnife = 9;
        InstanceGame();     
        LevelManager.Instance.LoadLv(12);
        EnemyRotate.Instance.loadLV12();

    }

    public void LoadLv13()
    {
        maxKnife = 9;
        InstanceGame();
        LevelManager.Instance.LoadLv(13);
        EnemyRotate.Instance.loadLV13();

    }

    public void LoadLv14()
    {
        maxKnife = 10;
        InstanceGame();
        LevelManager.Instance.LoadLv(14);
        EnemyRotate.Instance.loadLV14();

    }
    public void LoadLv15()
    {
        maxKnife = 10;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(15);
        EnemyRotate.Instance.loadLV15();

    }

    public void LoadLv16()
    {
        maxKnife = 12;
        InstanceGame();
        LevelManager.Instance.LoadLv(16);
        EnemyRotate.Instance.loadLV16();

    }
    public void LoadLv17()
    {
        maxKnife = 10;
        InstanceGame();
       
     
        LevelManager.Instance.LoadLv(17);
        EnemyRotate.Instance.loadLV17();

    }

    public void LoadLv18()
    {
        maxKnife = 8;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(18);
        EnemyRotate.Instance.loadLV18();

    }

    public void LoadLv19()
    {
        maxKnife = 12;
        InstanceGame();
      
      
        LevelManager.Instance.LoadLv(19);
        EnemyRotate.Instance.loadLV19();

    }

    public void LoadLv20()
    {
        maxKnife = 15;
        InstanceGame();
        
        
        LevelManager.Instance.LoadLv(20);
        EnemyRotate.Instance.loadLV20();

    }

    public void LoadLv21()
    {
        maxKnife = 13;
        InstanceGame();
        
        
        LevelManager.Instance.LoadLv(21);
        EnemyRotate.Instance.loadLV21();

    }

    public void LoadLv22()
    {
        maxKnife = 12;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(22);
        EnemyRotate.Instance.loadLV22();

    }

    public void LoadLv23()
    {
        maxKnife = 11;
        InstanceGame();
     
        LevelManager.Instance.LoadLv(23);
        EnemyRotate.Instance.loadLV23();

    }

    public void LoadLv24()
    {
        maxKnife = 12;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(24);
        EnemyRotate.Instance.loadLV24();

    }
    public void LoadLv25()
    {
        maxKnife = 15;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(25);
        EnemyRotate.Instance.loadLV25();

    }
    public void LoadLv26()
    {
        maxKnife = 13;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(26);
        EnemyRotate.Instance.loadLV26();

    }
    public void LoadLv27()
    {
        maxKnife = 13;
        InstanceGame();
      
        LevelManager.Instance.LoadLv(27);
        EnemyRotate.Instance.loadLV27();

    }
    public void LoadLv28()
    {
        maxKnife = 14;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(28);
        EnemyRotate.Instance.loadLV28();

    }
    public void LoadLv29()
    {
        maxKnife = 14;
        InstanceGame();
      
        LevelManager.Instance.LoadLv(29);
        EnemyRotate.Instance.loadLV29();

    }
    public void LoadLv30()
    {
        maxKnife = 10;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(30);
        EnemyRotate.Instance.loadLV30();

    }
    public void LoadLv31()
    {
        maxKnife = 12;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(31);
        EnemyRotate.Instance.loadLV31();

    }

    public void LoadLv32()
    {
        maxKnife = 15;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(32);
        EnemyRotate.Instance.loadLV32();

    }
    public void LoadLv33()
    {
        maxKnife = 12;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(33);
        EnemyRotate.Instance.loadLV33();

    }
    public void LoadLv34()
    {
        maxKnife = 15;
        InstanceGame();
   
        LevelManager.Instance.LoadLv(34);
        EnemyRotate.Instance.loadLV34();

    }
    public void LoadLv35()
    {
        maxKnife = 10;
        InstanceGame();
      
        LevelManager.Instance.LoadLv(35);
        EnemyRotate.Instance.loadLV35();

    }
    public void LoadLv36()
    {
        maxKnife = 13;
        InstanceGame();
  
        LevelManager.Instance.LoadLv(36);
        EnemyRotate.Instance.loadLV36();

    }
    public void LoadLv37()
    {
        maxKnife = 12;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(37);
        EnemyRotate.Instance.loadLV37();

    }
    public void LoadLv38()
    {
        maxKnife = 14;
        InstanceGame();
     
        LevelManager.Instance.LoadLv(38);
        EnemyRotate.Instance.loadLV38();

    }
    public void LoadLv39()
    {
        maxKnife = 10;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(39);
        EnemyRotate.Instance.loadLV39();

    }
    public void LoadLv40()
    {
        maxKnife = 13;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(40);
        EnemyRotate.Instance.loadLV40();

    }
    public void LoadLv41()
    {
        maxKnife = 13;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(41);
        EnemyRotate.Instance.loadLV41();

    }
    public void LoadLv42()
    {
        maxKnife = 11;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(42);
        EnemyRotate.Instance.loadLV42();

    }
    public void LoadLv43()
    {
        maxKnife = 10;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(43);
        EnemyRotate.Instance.loadLV43();

    }
    public void LoadLv44()
    {
        maxKnife = 13;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(44);
        EnemyRotate.Instance.loadLV44();

    }
    public void LoadLv45()
    {
        maxKnife = 15;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(45);
        EnemyRotate.Instance.loadLV45();

    }
    public void LoadLv46()
    {
        maxKnife = 13;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(46);
        EnemyRotate.Instance.loadLV46();

    }
    public void LoadLv47()
    {
        maxKnife = 12;
        InstanceGame();
      
        LevelManager.Instance.LoadLv(47);
        EnemyRotate.Instance.loadLV47();

    }
    public void LoadLv48()
    {
        maxKnife = 12;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(48);
        EnemyRotate.Instance.loadLV48();

    }

    public void LoadLv49()
    {
        maxKnife = 13;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(49);
        EnemyRotate.Instance.loadLV49();

    }
    public void LoadLv50()
    {
        maxKnife = 13;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(50);
        EnemyRotate.Instance.loadLV50();

    }
    public void LoadLv51()
    {
        maxKnife = 10;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(51);
        EnemyRotate.Instance.loadLV51();

    }
    public void LoadLv52()
    {
        maxKnife = 9;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(52);
        EnemyRotate.Instance.loadLV52();

    }
    public void LoadLv53()
    {
        maxKnife = 11;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(53);
        EnemyRotate.Instance.loadLV53();

    }
    public void LoadLv54()
    {
        maxKnife = 14;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(54);
        EnemyRotate.Instance.loadLV54();

    }
    public void LoadLv55()
    {
        maxKnife = 13;
        InstanceGame();
      
        LevelManager.Instance.LoadLv(55);
        EnemyRotate.Instance.loadLV55();

    }
    public void LoadLv56()
    {
        maxKnife = 11;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(56);
        EnemyRotate.Instance.loadLV56();

    }
    public void LoadLv57()
    {
        maxKnife = 12;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(57);
        EnemyRotate.Instance.loadLV57();

    }
    public void LoadLv58()
    {
        maxKnife = 11;
        InstanceGame();
       
        
        LevelManager.Instance.LoadLv(58);
        EnemyRotate.Instance.loadLV58();

    }
    public void LoadLv59()
    {
        maxKnife = 13;
        InstanceGame();
      
        LevelManager.Instance.LoadLv(59);
        EnemyRotate.Instance.loadLV59();

    }
    public void LoadLv60()
    {
        maxKnife = 15;
        InstanceGame();
      
        LevelManager.Instance.LoadLv(60);
        EnemyRotate.Instance.loadLV60();

    }

    public void LoadLv61()
    {
        maxKnife = 13;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(61);
        EnemyRotate.Instance.loadLV61();

    }

    public void LoadLv62()
    {
        maxKnife = 14;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(62);
        EnemyRotate.Instance.loadLV62();

    }

    public void LoadLv63()
    {
        maxKnife = 10;
        InstanceGame();
      
        LevelManager.Instance.LoadLv(63);
        EnemyRotate.Instance.loadLV63();

    }
    public void LoadLv64()
    {
        maxKnife = 13;
        InstanceGame();
      
        LevelManager.Instance.LoadLv(64);
        EnemyRotate.Instance.loadLV64();

    }
    public void LoadLv65()
    {
        maxKnife = 13;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(65);
        EnemyRotate.Instance.loadLV65();

    }
    public void LoadLv66()
    {
        maxKnife = 10;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(66);
        EnemyRotate.Instance.loadLV66();

    }
    public void LoadLv67()
    {
        maxKnife = 11;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(67);
        EnemyRotate.Instance.loadLV67();

    }
    public void LoadLv68()
    {
        maxKnife = 13;
        InstanceGame();
       
        LevelManager.Instance.LoadLv(68);
        EnemyRotate.Instance.loadLV68();

    }
    public void LoadLv69()
    {
        maxKnife = 13;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(69);
        EnemyRotate.Instance.loadLV69();

    }

    public void LoadLv70()
    {
        maxKnife = 15;
        InstanceGame();
        
        LevelManager.Instance.LoadLv(70);
        EnemyRotate.Instance.loadLV70();

    }
    public void GameOver()
    {
        EnemyRotate.Instance.SetBeginPlay(false);
        PlayerPrefs.SetInt("apple", appleScore);
        isGameOver = true;
        LeanTween.pause(enemyClone);
        if (Random.value < 0.3f)
        {
            if (!isShowIAds)
            {
                isShowIAds = true;
                GoogleAdMobController.Instance.RequestAndLoadInterstitialAd();
            }
        }
        Invoke("GameOver1", 0.7f);

    }
    public void SetIsGameOver(bool gameover)
    {
        isGameOver = gameover;
    }
    public bool GetIsGameOver()
    {
        return isGameOver;
    }
    void GameOver1()
    {

        Time.timeScale = 0;
        if (level > 2)
        {
            bool rd = Random.value > 0.5f;
            if (rd && !isContinuePlay)
            {
                uiGameOver.transform.Find("Restart").gameObject.SetActive(false);
                uiGameOver.transform.Find("NoThanks").gameObject.SetActive(true);
                uiGameOver.transform.Find("ContinueButton").gameObject.SetActive(true);
                isContinuePlay = true;
                uiSetting.SetActive(false);
                if (!isShowRewardAds)
                {
                    isShowRewardAds = true;
                    GoogleAdMobController.Instance.RequestAndLoadRewardedAd();
                }
            }
            else
            {
             
                uiGameOver.transform.Find("Restart").gameObject.SetActive(true);
                uiGameOver.transform.Find("NoThanks").gameObject.SetActive(false);
                uiGameOver.transform.Find("ContinueButton").gameObject.SetActive(false);
                uiSetting.SetActive(true);
            }
        }
        else
        {
            uiGameOver.transform.Find("Restart").gameObject.SetActive(true);
            uiGameOver.transform.Find("NoThanks").gameObject.SetActive(false);
            uiGameOver.transform.Find("ContinueButton").gameObject.SetActive(false);
            uiSetting.SetActive(true);
        }
        uiGameOver.SetActive(true);
        uiPlayObject.SetActive(false);

        uiTMPStageOver.text = "STAGE " + level;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }


    public void LevelUp()
    {
       
        GamePlay.Instance.SetSoundAOrE(false);
        EnemyRotate.Instance.SetBeginPlay(false);
        EnemyRotate.Instance.CleanEnemyToStand();
        level += 1;
        knifeThrowed = 0;
        isContinuePlay = false;
        Invoke("LoadLv" + level, 1.5f);
    }

    public void RestartGame()
    {
        if (isShowIAds)
        {
            isShowIAds = false;
            GoogleAdMobController.Instance.ShowInterstitialAd();
        }
        else
        {
            RestartGameAfterCheckAds();
        }
    }

    public void RestartGameAfterCheckAds()

    {
       
        level = 1;
        knifeThrowed = 0;
     
        EnemyRotate.Instance.CleanEnemyToStand();
        numberKnife = 0;
        isGameOver = false;
        isContinuePlay = false;
        Time.timeScale = 1;
        LoadLv1();
        uiGameOver.SetActive(false);
       
        uiPlayObject.SetActive(true);
        GamePlay.Instance.SetSoundAOrE(false);
    }


    public void ContinuePlay()
    {
        isShowRewardAds = false;
        GoogleAdMobController.Instance.ShowRewardedAd();
    }

    public void ContinuePlayAfterAds()
    {
        GamePlay.Instance.SetSoundAOrE(false);
        EnemyRotate.Instance.SetBeginPlay(true);
        uiGameOver.SetActive(false);
        uiPlayObject.SetActive(true);
        Time.timeScale = 1;
        LeanTween.resume(enemyClone);
        isGameOver = false;
        for (int i = maxKnife - knifeThrowed; i < maxKnife - numberKnife; i++) { 
            if(i>-1) 
            uiItem[i].GetComponent<Image>().sprite = WhiteItem;
            }
        knifeThrowed = numberKnife;
        Hand.Instance.ShowKnifeOfHand();
    }

    
}

