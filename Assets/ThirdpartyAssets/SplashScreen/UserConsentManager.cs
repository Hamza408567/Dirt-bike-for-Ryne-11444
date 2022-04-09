using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using GoogleMobileAds.Api;

public class UserConsentManager : MonoBehaviour
{
    public GameObject TermsPanel;
    public GameObject PrivacyButton, Background;
    public Text BlinkingText;
    bool userConsent = false;
    public Slider slider;
    // Use this for initialization
    void Start ()
    {
      //  GameAnalyticsSDK.GameAnalytics.Initialize();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (PlayerPrefs.GetInt("TermsShown", 0) == 0)
            {
                TermsPanel.SetActive(true);
            }
            else
            {
                if (PlayerPrefs.GetInt("userConsent") == 0)
                {
                    userConsent = false;
                }
                else
                {
                    userConsent = true;
                }

                Debug.Log("***** Setting User Consent For Consoli: " + userConsent.ToString() + " *****");
                //Set User Consent
               // ConsoliAds.Instance.initialize(userConsent);
                //Load Next Scene
                StartCoroutine(Loading());
                Invoke("LoadNextScene", 5.0f);
            }
        }
        //If AnyOther Scene show Privacy Button
        else
        {
            Background.SetActive(false);
            PrivacyButton.SetActive(true);
        }
        
           
    }

    public void OnClickYes ()
    {
        PlayerPrefs.SetInt("userConsent", 1);
        PlayerPrefs.SetInt("TermsShown", 1);
        userConsent = true;

       // if (ConsoliAds.Instance)
          //  ConsoliAds.Instance.initialize(userConsent);

        Debug.Log("***** Setting User Consent For Consoli: " + userConsent.ToString() + " *****");

        TermsPanel.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(Loading());
            Invoke("LoadNextScene", 5.0f);
            ;
        }
        else
        {

        }
    }


    public void OnClickNo ()
    {
        PlayerPrefs.SetInt("userConsent", 0);
        PlayerPrefs.SetInt("TermsShown", 1);
        userConsent = false;

        

        Debug.Log("***** Setting User Consent For Consoli: " + userConsent.ToString() + " *****");

        TermsPanel.SetActive(false);


        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(Loading());
            Invoke("LoadNextScene", 5.0f);

        }
        else
        {

        }
    }

    public void LoadNextScene ()
    {
      //  GameAnalyticsSDK.GameAnalytics.Initialize();
        SceneManager.LoadScene(1);
    }

    IEnumerator Loading ()
    {

        while (slider.value < 1)
        {
            slider.value = slider.value + 0.01f;
            yield return new WaitForSeconds(0.02f);
            //  BlinkingText.gameObject.SetActive(!BlinkingText.gameObject.activeSelf);
        }


    }

}