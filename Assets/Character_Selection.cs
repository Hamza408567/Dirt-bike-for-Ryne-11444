using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Selection : MonoBehaviour
{
    public GameObject[] AllCharacter;
    public Transform characterPosition;
    [HideInInspector]
    public int selectedCahracter;
    [HideInInspector]
    public int previousCaharacter;
    public int[] characterPrice;
    public GameObject start, locked, unlock;
    public Text characterPricepricetext;
    void Start()
    {
        PlayerPrefs.SetInt(Constants.unlockBike + 0, 1);
        selectedCahracter = PlayerPrefs.GetInt(Constants.SelectedCharacter);
        AllCharacter[selectedCahracter].SetActive(true);
        AllCharacter[selectedCahracter].transform.position = characterPosition.position;
        AllCharacter[selectedCahracter].transform.rotation = characterPosition.rotation;
        CheckStatus();
    }

    public void next(int i)
    {

        selectedCahracter = selectedCahracter + i;
        //check previous car
        if (i == 1)
        {
            previousCaharacter = selectedCahracter - 1;
        }
        else if (i == -1)
        {
            previousCaharacter = selectedCahracter + 1;
        }
        //Control array can't be out of index
        if (selectedCahracter < 0)
        {
            selectedCahracter = AllCharacter.Length - 1;
        }
        if (selectedCahracter > AllCharacter.Length - 1)
        {
            selectedCahracter = 0;
        }
        // Activate Selected car and Deactivate previous car
        AllCharacter[selectedCahracter].transform.position = characterPosition.position;
        AllCharacter[selectedCahracter].transform.rotation = characterPosition.rotation;
        AllCharacter[previousCaharacter].SetActive(false);
        AllCharacter[selectedCahracter].SetActive(true);
        PlayerPrefs.SetInt(Constants.SelectedCharacter, selectedCahracter);
        //check weather the car lock or unlock
        CheckStatus();
    }
    public void CheckStatus()
    {
        //if user price grater then car and car are locked price then unlock the car.
        if (characterPrice[selectedCahracter] < PlayerPrefs.GetInt(Constants.totalcoin) && PlayerPrefs.GetInt(Constants.unlockCharacter + selectedCahracter) != 1)
        {
            unlock.SetActive(true);
            start.SetActive(false);
            locked.SetActive(false);
            // Debug.LogError("please unlock the car");
        }
        //if user price is less then car price and the car is locked then the car is locked.
        if (characterPrice[selectedCahracter] > PlayerPrefs.GetInt(Constants.totalcoin) && PlayerPrefs.GetInt(Constants.unlockCharacter + selectedCahracter) != 1)
        {
            start.SetActive(false);
            locked.SetActive(true);
            unlock.SetActive(false);
            //   Debug.LogError("car locked="+ carPrice[selectedCar]);

        }
        //if car unlocked then start the game.
        if (PlayerPrefs.GetInt(Constants.unlockCharacter + selectedCahracter) == 1)
        {
            start.SetActive(true);
            locked.SetActive(false);
            unlock.SetActive(false);
            // Debug.LogError("start the game");
        }
        characterPricepricetext.text = characterPrice[selectedCahracter] + "";

    }
    public void UnlockBike()
    {
        PlayerPrefs.SetInt(Constants.unlockCharacter + selectedCahracter, 1);
        PlayerPrefs.SetInt(Constants.totalcoin, PlayerPrefs.GetInt(Constants.totalcoin) - characterPrice[selectedCahracter]);
        unlock.SetActive(false);
        start.SetActive(true);
       // UIHandler.instance.UpdateCoins();
    }
}
