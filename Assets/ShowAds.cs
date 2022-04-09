using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAds : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        GoogleMobileAdsManager.Instance.ShowSmallAdmobBanner();
       // GoogleMobileAdsDemoScript.showBanner = true;
    }
    private void OnDisable()
    {
        GoogleMobileAdsManager.Instance.HideSmallAdmobBanner();
      //  GoogleMobileAdsDemoScript.showBanner = false;
    }
   
}
