using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class UpdateCoins : MonoBehaviour
{
    public Text coin;
    void Update()
    {
        coin.text = PlayerPrefs.GetInt(Constants.totalcoin)+"";
    }
}
