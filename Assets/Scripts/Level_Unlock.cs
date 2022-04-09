using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class Level_Unlock : MonoBehaviour
{
    public Button[] levelUnlockMod1; 
    public Button[] levelUnlockMod2; 
    public Button[] levelUnlockMod3;
    public GameObject[] modeLevel;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("ModeSelect" )==0)
        {
            modeLevel[0].SetActive(true);
        }if (PlayerPrefs.GetInt("ModeSelect" )==1)
        {
            modeLevel[1].SetActive(true);
        }if (PlayerPrefs.GetInt("ModeSelect" )==2)
        {
            modeLevel[2].SetActive(true);
        }
    }
    private void OnDisable()
    {
        modeLevel[0].SetActive(false);
        modeLevel[1].SetActive(false);
        modeLevel[2].SetActive(false);
    }

    //levl unlock by complete mission
    void Start()
    {
       // if (PlayerPrefs.GetInt("levelUnlock") <= 9)
       // {
            for (int i = 0; i < PlayerPrefs.GetInt("levelUnlock"); i++)
            {
                levelUnlockMod1[i].interactable = true;
            }
            for (int i = 0; i < PlayerPrefs.GetInt("levelUnlock1"); i++)
            {
                levelUnlockMod2[i].interactable = true;
            }
            for (int i = 0; i < PlayerPrefs.GetInt("levelUnlock2"); i++)
            {
                levelUnlockMod3[i].interactable = true;
            }
       // }
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    /// <summary>
    /// level unlock by in app
    /// </summary>
    public void Unlock_Levels()
    {
        PlayerPrefs.SetInt("levelUnlock", levelUnlockMod1.Length);
        PlayerPrefs.SetInt("levelbuyed", 1);
        for (int i = 0; i < PlayerPrefs.GetInt("levelUnlock"); i++)
        {
            levelUnlockMod1[i].interactable = true;
        }
        Invoke("HidelevelPanel", 0.2f);
    }
    public void HidelevelPanel()
    {
        Main_Menu_Manager.Instance.unlockLevels.SetActive(false);
    }
}
