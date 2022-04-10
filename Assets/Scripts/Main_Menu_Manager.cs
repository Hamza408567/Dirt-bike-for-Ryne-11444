using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu_Manager : MonoBehaviour
{//alll playerprefs
    public PlayerPrefs reward;
    public PlayerPrefs level;
    public PlayerPrefs levelname;
    public PlayerPrefs bikechange;
    public PlayerPrefs Coins;
    public PlayerPrefs TotalCoins;
    public PlayerPrefs sound;
    public PlayerPrefs nextlevel;
    public PlayerPrefs Concent;

    //when player wants to play next level
    public PlayerPrefs Next;
   
    //Removes all ads
    public PlayerPrefs removeads;
    public PlayerPrefs adsbuyed;
   
    //hide all in app panels first time;
    public PlayerPrefs inapp;

    //when level buyed 
    public PlayerPrefs levelUnlock;
    public PlayerPrefs levelbuyed;
    
    
    //when bike buyed 
    public PlayerPrefs bikeunlock;
    public PlayerPrefs bikebuyed;

    public GameObject mainPanel,ModeSelectionPanel, bikeSelectionPanel,bikePanel2, levelSelectionPanel,SettingPanel,levelSelectDialogBox,shopPanel,lodingPanel,exitPanel;
    public GameObject unlockEveryThing, unlockBikes, unlockLevels, unlockAds, unlockCoins;
    public GameObject bikeStage;
    public Text rewartText,levelNameText,totalCoinText1, totalCoinText2, totalCoinText3;
    public AudioSource clickEffect;
    public Bike_Customization BC;
    public Level_Unlock LU;
    public Button soundButton;



    public static Main_Menu_Manager Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("removeads") == 0)
        {
            //UnityAdController.Instance.ShowUnityAd();
           // AdsManager.Instance.HideBanner();
           // AdsManager.Instance.ShowBanner(0);
        }
        //for test
        // PlayerPrefs.SetInt("levelUnlock",  4);
        // PlayerPrefs.SetInt("TotalCoins", 125000);
        //PlayerPrefs.SetInt("levelUnlock", 10);
        //PlayerPrefs.SetInt("inapp", 1);
        lodingPanel.SetActive(false);
        if(PlayerPrefs.GetInt("nextlevel") ==1)
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
                //GoogleMobileAdsDemoScript.showInter = true;
              //  AdsManager.Instance.HideBanner();
              //  AdsManager.Instance.ShowBanner(0);
            }
            levelSelectionPanel.SetActive(true);
            PlayerPrefs.SetInt("nextlevel", 0);
        }
        lodingPanel.SetActive(false);

        //For In appp
        //if(PlayerPrefs.GetInt("inapp") == 1 && (PlayerPrefs.GetInt("bikebuyed") == 0 || PlayerPrefs.GetInt("levelbuyed") == 0))
        //{
        //    unlockEveryThing.SetActive(true);
        //}
        //else
        //{
        //    unlockEveryThing.SetActive(false);
        //}
        //if (PlayerPrefs.GetInt("adsbuyed") == 1)
        //{
        //    unlockAds.SetActive(false);
        //}
    }


    public void Update()
    {
        totalCoinText1.text = PlayerPrefs.GetInt("TotalCoins").ToString();
        totalCoinText2.text = PlayerPrefs.GetInt("TotalCoins").ToString();
        totalCoinText3.text = PlayerPrefs.GetInt("TotalCoins").ToString();
       
    }
    public void SelectMode(int i)
    {
        PlayerPrefs.SetInt("ModeSelect", i);
    }
    public void Main_menu(string s)
    {
        if (s == "shop")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
              //  GoogleMobileAdsDemoScript.showBanner = false;
                //  AdsManager.Instance.HideBanner();
            }
            if (PlayerPrefs.GetInt("inapp") == 1)
            {
                unlockCoins.SetActive(true);
                // Start_Wait.instance.Invoke("wait", 0.5f);
            }
            shopPanel.gameObject.SetActive(true);
            clickEffect.Play();
        }
        else if (s == "modeselection")
        {
            ModeSelectionPanel.SetActive(true);
            mainPanel.SetActive(false);
            clickEffect.Play();
        }
        else if (s == "BTMS")
        {
            ModeSelectionPanel.SetActive(true);
            bikeSelectionPanel.SetActive(false);
            bikePanel2.SetActive(false);
            bikeStage.SetActive(false);
            Debug.LogError("modselection");
            clickEffect.Play();
        }

        else if (s == "closeshop")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
             //   GoogleMobileAdsDemoScript.showBanner = true;
              //  GoogleMobileAdsDemoScript.showBanner = false;
                //  AdsManager.Instance.HideBanner();
                //  AdsManager.Instance.ShowBanner(0);
            }
            shopPanel.gameObject.SetActive(false);
            clickEffect.Play();
        }
        else if (s == "garage")
        {
            clickEffect.Play();
        }
        else if (s == "LSDB")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {

                // AdsManager.Instance.HideBanner();
            }
            levelSelectDialogBox.SetActive(true);
            clickEffect.Play();
        }


        else if (s == "bikeselection")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
                // AdsManager.Instance.HideBanner();

              //  GoogleMobileAdsDemoScript.showBanner = false;
              //  GoogleMobileAdsDemoScript.showInter = true;
                // ConsoliAds.Instance.ShowInterstitial(0);
            }
            //For In App

            //if (PlayerPrefs.GetInt("inapp") == 1 && PlayerPrefs.GetInt("bikebuyed") == 0)
            //{

            //    unlockBikes.SetActive(true);
            //    bikeStage.SetActive(false);
            //}
            //else
            //{
            //    bikeStage.SetActive(true);
            //}

            bikeStage.SetActive(true);
            ModeSelectionPanel.SetActive(false);
            bikeSelectionPanel.SetActive(true);
            bikePanel2.SetActive(true);
            clickEffect.Play();
        }
        else if (s == "backtomain")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
              //  GoogleMobileAdsDemoScript.showBanner = true;
              //  GoogleMobileAdsDemoScript.showBanner = false;
                //AdsManager.Instance.HideBanner();
                //AdsManager.Instance.ShowBanner(0);
            }
            //For In app
            //if (PlayerPrefs.GetInt("inapp") == 1 && (PlayerPrefs.GetInt("bikebuyed") == 0 || PlayerPrefs.GetInt("levelbuyed") == 0))
            //{
            //    unlockEveryThing.SetActive(true);
            //}
            //else
            //{
            //    unlockEveryThing.SetActive(false);
            //}
            mainPanel.SetActive(true);
            ModeSelectionPanel.SetActive(false);
            clickEffect.Play();
        }
        else if (s == "rateus")
        {
             Application.OpenURL("https://play.google.com/store/apps/details?id=com.hitech.extreme.dirt.bike");
            clickEffect.Play();
        }
        else if (s == "moregames")
        {
             Application.OpenURL("https://play.google.com/store/apps/developer?id=Hi-Tech+Studios");
            clickEffect.Play();
        }
        else if (s == "setting")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
             //   GoogleMobileAdsDemoScript.showBanner = true;
              //  GoogleMobileAdsDemoScript.showBanner = false;
                //  AdsManager.Instance.HideBanner();
                //  AdsManager.Instance.ShowBanner(0);
            }
            SettingPanel.SetActive(true);
            clickEffect.Play();
        }
        else if (s == "closesetting")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
             //   GoogleMobileAdsDemoScript.showBanner = true;
             //   GoogleMobileAdsDemoScript.showBanner = false;
                // AdsManager.Instance.HideBanner();
                // AdsManager.Instance.ShowBanner(0);
            }
            SettingPanel.SetActive(false);
            clickEffect.Play();
        }
        /////////////////////////////////////////////
        else if (s == "exit")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
               // UnityAdController.Instance.ShowUnityAd();
                // AdsManager.Instance.HideBanner();
                // ConsoliAds.Instance.ShowInterstitial(0);
                // AdsManager.Instance.ShowBanner(1);
            }
            //
            exitPanel.SetActive(true);
            clickEffect.Play();
        }
        else if (s == "yes")
        {
            Application.Quit();
            clickEffect.Play();
        }
        else if (s == "no")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
                //  AdsManager.Instance.HideBanner();
                // AdsManager.Instance.ShowBanner(0);
            }
            exitPanel.SetActive(false);
            clickEffect.Play();
        }


        else if (s == "levelselection")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
              //  GoogleMobileAdsDemoScript.showBanner = true;
              //  GoogleMobileAdsDemoScript.showBanner = false;
                // AdsManager.Instance.HideBanner();
                // AdsManager.Instance.ShowBanner(0);
            }

            //For in app
            //if (PlayerPrefs.GetInt("inapp") == 1 && PlayerPrefs.GetInt("levelbuyed") == 0)
            //{
            //    unlockLevels.SetActive(true);

            //}
            levelSelectionPanel.SetActive(true);
            bikeSelectionPanel.SetActive(false);
            bikePanel2.SetActive(false);
            bikeStage.SetActive(false);
            clickEffect.Play();
        }
        else if (s == "backtolevelselection")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
                // AdsManager.Instance.HideBanner();
            }
            //For In app
            //if (PlayerPrefs.GetInt("inapp") == 1 && PlayerPrefs.GetInt("bikebuyed") == 0)
            //{

            //    unlockBikes.SetActive(true);
            //    bikeStage.SetActive(false);
            //}
            //else
            //{
            //    bikeStage.SetActive(true);
            //}

            bikeStage.SetActive(true);
            levelSelectionPanel.SetActive(false);
            bikeSelectionPanel.SetActive(true);
            bikePanel2.SetActive(true);

            clickEffect.Play();
        }
        else if (s == "loading")
        {
           // Debug.LogError("call loading panel");
            Time.timeScale = 1f;
            clickEffect.Play();
            lodingPanel.SetActive(true);
            Invoke("StartGamplay", 1.8f);
            if (PlayerPrefs.GetInt("removeads") == 0)
            {

              //  GoogleMobileAdsDemoScript.showBanner = false;
             //   GoogleMobileAdsDemoScript.showInter = true;
                //  AdsManager.Instance.HideBanner();
                //  ConsoliAds.Instance.ShowInterstitial(2);
            }
        }
        else if (s == "LSDBclose")
        {
            if (PlayerPrefs.GetInt("removeads") == 0)
            {
             //   GoogleMobileAdsDemoScript.showBanner = true;
              //  GoogleMobileAdsDemoScript.showBanner = false;
                //  AdsManager.Instance.HideBanner();
                //  AdsManager.Instance.ShowBanner(0);
            }
            levelSelectDialogBox.SetActive(false);
            clickEffect.Play();
        }

    }
    public void StartGamplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Sound()
    {
        clickEffect.Play();
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            AudioListener.pause = false;
            PlayerPrefs.SetInt("sound", 0);
            //soundButton.colors = Color.red;
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            AudioListener.pause = true;
            PlayerPrefs.SetInt("sound", 1);
        }

    }



    /// <summary>
    /// Level Selection 
    /// </summary>
    /// <param name="i"></param>
    public void Level_selection(int i)
    {
        PlayerPrefs.SetInt("level", i);
        clickEffect.Play();
    }
    public void Reward_set(int r)
    {
        PlayerPrefs.SetInt("reward", r);
        rewartText.text = PlayerPrefs.GetInt("reward").ToString();
    }
    public void Set_level_name(string s)
    {
        PlayerPrefs.SetString("levelname", s);
        levelNameText.text = PlayerPrefs.GetString("levelname").ToString();
    }


    /// <summary>
    /// Shoping and all Inapps
    /// </summary>
    /// <param name="p"></param>
    /// 


    public void Inapp_manager(string s)
    {
        if (s == "closecoinspanel")
        {
            unlockCoins.SetActive(false);
        }
        else if (s == "closelevelpanel")
        {
            unlockLevels.SetActive(false);
        }
        else if (s == "closebikepanel")
        {
            unlockBikes.SetActive(false);
            bikeStage.SetActive(true);
        }
        else if (s == "closeULE")
        {
            unlockEveryThing.SetActive(false);
        }

    }
    public void Shop(int p)
    {
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") +p);
        Debug.Log("buy coins"+ PlayerPrefs.GetInt("TotalCoins"));
        clickEffect.Play();
    }
    public void shop_AllCoins()
    {
        
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + 3000 + 6000+ 9000+ 12000);
            Debug.Log("buy coins" + PlayerPrefs.GetInt("TotalCoins"));
            clickEffect.Play();
            Invoke("HidecoinsPanel", 0.2f);
    }
    public void Remove_Ads()
    {
        PlayerPrefs.SetInt("removeads",1);
        PlayerPrefs.SetInt("adsbuyed", 1);
        // unlockAds.SetActive(false); 
        Invoke("HideadsPanel", 0.2f);
    } 
    public void Unlock_EveryThing()
    {
        PlayerPrefs.SetInt("removeads", 1);
        PlayerPrefs.SetInt("adsbuyed", 1);
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + 3000 + 6000 + 9000 + 12000);
        Debug.Log("buy coins" + PlayerPrefs.GetInt("TotalCoins"));
        clickEffect.Play();
        unlockAds.SetActive(false);
        BC.Unlock_Bikes();
        LU.Unlock_Levels();
        Invoke("HideEverythingPanel", 0.2f);

    }

   //hide in app panel after buy
   public void HideEverythingPanel()
    {
        unlockEveryThing.SetActive(false);
    }public void HideadsPanel()
    {
        unlockAds.SetActive(false);
    }public void HidecoinsPanel()
    {
        unlockCoins.SetActive(false);
    }
}
