using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bike_Slection : MonoBehaviour
{
    public GameObject[] AllBikes;
    public Transform carPosition;
    [HideInInspector]
    public int selectedBike;
    [HideInInspector]
    public int previousBike;
    public int[] BikePrice;
    public GameObject start, locked, unlock;
    public Text bikepricetext;
    void Start()
    {
        PlayerPrefs.SetInt(Constants.unlockBike + 0, 1);
        selectedBike = PlayerPrefs.GetInt(Constants.selectedBike);
        AllBikes[selectedBike].SetActive(true);
        AllBikes[selectedBike].transform.position = carPosition.position;
        AllBikes[selectedBike].transform.rotation = carPosition.rotation;
        CheckStatus();
    }

    public void next(int i)
    {

        selectedBike = selectedBike + i;
        //check previous car
        if (i == 1)
        {
            previousBike = selectedBike - 1;
        }
        else if (i == -1)
        {
            previousBike = selectedBike + 1;
        }
        //Control array can't be out of index
        if (selectedBike < 0)
        {
            selectedBike = AllBikes.Length - 1;
        }
        if (selectedBike > AllBikes.Length - 1)
        {
            selectedBike = 0;
        }
        // Activate Selected car and Deactivate previous car
        AllBikes[selectedBike].transform.position = carPosition.position;
        AllBikes[selectedBike].transform.rotation = carPosition.rotation;
        AllBikes[previousBike].SetActive(false);
        AllBikes[selectedBike].SetActive(true);
        PlayerPrefs.SetInt(Constants.selectedBike, selectedBike);
        //check weather the car lock or unlock
        CheckStatus();
    }
    public void CheckStatus()
    {
        //if user price grater then car and car are locked price then unlock the car.
        if (BikePrice[selectedBike] < PlayerPrefs.GetInt(Constants.totalcoin) && PlayerPrefs.GetInt(Constants.unlockBike + selectedBike) != 1)
        {
            unlock.SetActive(true);
            start.SetActive(false);
            locked.SetActive(false);
            // Debug.LogError("please unlock the car");
        }
        //if user price is less then car price and the car is locked then the car is locked.
        if (BikePrice[selectedBike] > PlayerPrefs.GetInt(Constants.totalcoin) && PlayerPrefs.GetInt(Constants.unlockBike + selectedBike) != 1)
        {
            start.SetActive(false);
            locked.SetActive(true);
            unlock.SetActive(false);
            //   Debug.LogError("car locked="+ carPrice[selectedCar]);

        }
        //if car unlocked then start the game.
        if (PlayerPrefs.GetInt(Constants.unlockBike + selectedBike) == 1)
        {
            start.SetActive(true);
            locked.SetActive(false);
            unlock.SetActive(false);
            // Debug.LogError("start the game");
        }
        bikepricetext.text = BikePrice[selectedBike] + "";

    }
    public void UnlockBike()
    {
        PlayerPrefs.SetInt(Constants.unlockBike + selectedBike, 1);
        PlayerPrefs.SetInt(Constants.totalcoin, PlayerPrefs.GetInt(Constants.totalcoin) - BikePrice[selectedBike]);
        unlock.SetActive(false);
        start.SetActive(true);
       // UIHandler.instance.UpdateCoins();
    }
}
