using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ConcentPanel;
    
    void Start()
    {
        InitConsoli();
    }
    void InitConsoli()
    {
       // ConsoliAds.Instance.initialize(true);
        Invoke("Load_concent", 1.8f);
    }
    public void Load_concent()
    {
        if(PlayerPrefs.GetInt("Concent")==0)
        {
            ConcentPanel.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Main Manue");
        }
        
    }
    public void Yes()
    {
        PlayerPrefs.SetInt("Concent", 1);
        SceneManager.LoadScene("Main Manue");

    }
    public void No()
    {
        Application.Quit();
    }
}
