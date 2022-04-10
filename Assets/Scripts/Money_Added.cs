using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money_Added : MonoBehaviour
{
    private int moneyAdded;
    public Text totalCoinForCoplete;
    public int Index;
    void Start()
    {
        moneyAdded = PlayerPrefs.GetInt("TotalCoins");
        moneyAdded = moneyAdded + PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetInt("TotalCoins", moneyAdded);
        //For complete Level
        if(this.gameObject.name== "Complete".ToString())
        {
            Debug.Log("complete panel");
            if(PlayerPrefs.GetInt("levelbuyed")==0)
            {
                if (PlayerPrefs.GetInt("ModeSelect") == 0)
                {
                    PlayerPrefs.SetInt("levelUnlock", Game_controller.instance.level + 2);
                }
                if (PlayerPrefs.GetInt("ModeSelect") == 1)
                {
                    PlayerPrefs.SetInt("levelUnlock1", Game_controller.instance.level + 2);
                }

                if (PlayerPrefs.GetInt("ModeSelect") == 2)
                {
                    PlayerPrefs.SetInt("levelUnlock2", Game_controller.instance.level + 2);
                }
            }
           // Debug.Log("mission complete"+ PlayerPrefs.GetInt("levelUnlock"));
            moneyAdded = moneyAdded + PlayerPrefs.GetInt("reward");
            totalCoinForCoplete.text = (PlayerPrefs.GetInt("Coins") + PlayerPrefs.GetInt("reward")).ToString();
            PlayerPrefs.SetInt("TotalCoins", moneyAdded);
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("removeads") == 0)
        {
           // UnityAdController.Instance.ShowUnityAd();
           // AdsManager.Instance.HideBanner();
           // ConsoliAds.Instance.ShowInterstitial(Index);
           // AdsManager.Instance.ShowBanner(Index);
        }
    }
    private void OnDisable()
    {
        if (PlayerPrefs.GetInt("removeads") == 0)
        {
          
            //GoogleMobileAdsDemoScript.showBanner = false;
            //  AdsManager.Instance.HideBanner();
        }
    }
}
