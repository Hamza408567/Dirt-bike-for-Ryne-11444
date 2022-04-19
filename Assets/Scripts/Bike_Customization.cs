using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bike_Customization : MonoBehaviour
{

    public GameObject[] AllBikes;
    public bool[] bikebuyed;
    public Button playButton;
    public Button buyButton;
    public Text  moneyText,buyText;
    public Image sadEmoji;
    public int price;
    public int index;
    public Color goldColor;
    public int rotatespeed;
    void Start()
    {
        //by default
        index = PlayerPrefs.GetInt("bikechange");
        for(int i=0;i<bikebuyed.Length;i++)
        {
            if(PlayerPrefs.GetInt("bikeunlock"+index)==1)
            {
                bikebuyed[index] = true;
            }
        }
        //bikeBlack.mainTexture = AllBikes[index];
        //bikeRef.mainTexture = AllBikes[index];
        //bikeBody.mainTexture = AllBikes[index];
        moneyText.text = 0.ToString();
       // bikebuyed = new bool[bikeTexture.Length];
    }
    private void Update()
    {
       // this.transform.rotation *= Quaternion.Euler(0, rotatespeed * Time.deltaTime,0 );
        if (index != 0 )
        {
            if(bikebuyed[index]==true)
            {
                playButton.gameObject.SetActive(true);
                buyButton.gameObject.SetActive(false);
                sadEmoji.gameObject.SetActive(false);
                moneyText.color = Color.Lerp(Color.red, goldColor, 2);
                PlayerPrefs.SetInt("bikechange",index);
                PlayerPrefs.SetInt("bikeunlock" + index, 1);
            }
            else
            {
                // playText.text = "buy";
                buyButton.gameObject.SetActive(true);
                playButton.gameObject.SetActive(false);
             
            }
            //disable only when buyer did no have enough mony
              if(PlayerPrefs.GetInt("TotalCoins")>=(price*index))
              {
                if(bikebuyed[index]==true)
                {
                   // sadEmoji.gameObject.SetActive(false);
                }
                else
                {
                    buyButton.interactable = true;
                    buyText.gameObject.SetActive(true);
                    // playText.gameObject.SetActive(true);
                    sadEmoji.gameObject.SetActive(false);
                    moneyText.color = Color.Lerp(Color.red, goldColor, 2);
                }
                
              }
              else
              {
                if (bikebuyed[index] == true)
                {

                }
                else
                {
                    buyButton.interactable = false;
                    buyText.gameObject.SetActive(false);
                    // playText.gameObject.SetActive(false);
                    playButton.gameObject.SetActive(false);
                    sadEmoji.gameObject.SetActive(true);
                    moneyText.color = Color.Lerp(goldColor, Color.white, 2);
                }
              }
        }
        else
        {
            //playText.text = "play";
            playButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
            //playButton.interactable = true;
            sadEmoji.gameObject.SetActive(false);
            moneyText.color = Color.Lerp(Color.red, goldColor, 2);
        }
    }
    public void Next_bike(int i)
    {
        Main_Menu_Manager.Instance.clickEffect.Play();
        if (!(index >= (AllBikes.Length)-1))
        {
            index = index + i;
            //bikeBlack.mainTexture = AllBikes[index];
            //bikeRef.mainTexture = AllBikes[index];
            //bikeBody.mainTexture = AllBikes[index];
            AllBikes[index].SetActive(true);
            if(bikebuyed[index]==true)
            {
                moneyText.text = 0.ToString();
            }
            else
            {
                moneyText.text = (price * index).ToString();
            }
           
           
        }
        else if (index >= (AllBikes.Length)-1)
        {
            index = 0;
            //bikeBlack.mainTexture = AllBikes[index];
            //bikeRef.mainTexture = AllBikes[index];
            //bikeBody.mainTexture = AllBikes[index];
            AllBikes[index].SetActive(true);
            if (bikebuyed[index] == true)
            {
                moneyText.text = 0.ToString();
            }
            else
            {
                moneyText.text = (price * index).ToString();
            }
        }

    }
    public void previous_bike(int i)
    {
        Main_Menu_Manager.Instance.clickEffect.Play();
        if (!(index<=0))
        {
            index = index - i;
            //bikeBlack.mainTexture = AllBikes[index];
            //bikeRef.mainTexture = AllBikes[index];
            //bikeBody.mainTexture = AllBikes[index];

            if (bikebuyed[index] == true)
            {
                moneyText.text = 0.ToString();
            }
            else
            {
                moneyText.text = (price * index).ToString();
            }
        }
        else if (index <= 0)
        {
            index = (AllBikes.Length) - 1;
            Debug.Log("value of a=" + index);
            //bikeBlack.mainTexture = AllBikes[index];
            //bikeRef.mainTexture = AllBikes[index];
            //bikeBody.mainTexture = AllBikes[index];
            if (bikebuyed[index] == true)
            {
                moneyText.text = 0.ToString();
            }
            else
            {
                moneyText.text = (price * index).ToString();
            }
        }
    }
    public void bike_Buy()
    {
        Main_Menu_Manager.Instance.clickEffect.Play();
        if (bikebuyed[index] == true)
        {
            playButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("TotalCoins",PlayerPrefs.GetInt("TotalCoins")-(price*index));
            moneyText.text = 0.ToString();
           // Main_Menu_Manager.Instance.totalCoinText1.text = PlayerPrefs.GetInt("TotalCoins").ToString();
          //  Main_Menu_Manager.Instance.totalCoinText2.text = PlayerPrefs.GetInt("TotalCoins").ToString();
           // Main_Menu_Manager.Instance.totalCoinText3.text = PlayerPrefs.GetInt("TotalCoins").ToString();
            playButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }
        bikebuyed[index] = true;
    }



    //In appp buy bike
    public void Unlock_Bikes()
    {
        PlayerPrefs.SetInt("bikebuyed", 1);
        for (int i=0;i<AllBikes.Length;i++)
        {
            PlayerPrefs.SetInt("bikeunlock"+i,1);
            bikebuyed[i] = true;

        }
        Invoke("HidebikePanel", 0.2f);
    }
    public void HidebikePanel()
    {
       Main_Menu_Manager.Instance.unlockBikes.SetActive(false);
    }
}
