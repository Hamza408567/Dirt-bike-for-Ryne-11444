using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemySpawner : MonoBehaviour
{
    public GameObject kickButton;
    public GameObject kickImage;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SelectedLevel").Equals(0))
        {
            kickButton.SetActive(false);
            kickImage.SetActive(false);
        }
        else
        {
            kickButton.SetActive(true);
            kickImage.SetActive(true);
        }
        
    }

     
}//the End
