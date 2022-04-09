using SWS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    [Header("Seats all the reference")]
    public GameObject[] path;
    public GameObject enableEnemy1;
    public GameObject enableEnemy2;
    public GameObject enableHeardels1;
    public GameObject enableHeardels2;
    public GameObject finishPoint;
    public GameObject[] allEnemysCars;
    public Transform[] enemySpawnPosition;
    public Transform playerSpawnPosition;
    public GameObject[] allBarrels;
    public GameObject[] allCrate;
    public GameObject level3FinishPoint;
    public Player_controller player;
    //spawn new cars when "reach" is occure
    //public GameObject reach;
    public int destroyTotalCars;
    public int destroyTotalBarrals;
    public int destroyTotalCrate;
    //when task is complete
    
    public int carCoins, BarrelCoins,crateCoins;
    private int calculateCarCoins, calculateBarrelsCoins,calculateCrateCoins;
    public GameObject showCoinVisual;
    public Text showCoins;
    public GameObject showCoinVisualOnCreate;
    public Text showCoinsOnCreate;
   
    public GameObject cinematicCamraStart, playerCamra, cinematicCamraVictory;
    public int startWait;
    public Text taskToAchiveText;
    public Text taskTotalText;
    public int task;
    public Image taskBackground;

    //for level fails
    [Header("For Level Fail")]
    public Text totalVehicalsDdestroyText;
    public Text totalDestroyCrate;
    public Text destroyBarrelsText;
    public Text totalCoinsText;
    //for level complete
    [Header("For Level Complete")]
    public Text totalVehicalsDdestroyText2;
    public Text totalDestroyCrate2;
    public Text destroyBarrelsText2;
    public Text totalCoinsText2;
    public Text levelReward;

    private void OnEnable()
    {
        Event_manager.carDestroy += Task;
    }
    private void Awake()
    {
        if (PlayerPrefs.GetInt("level") == 0|| PlayerPrefs.GetInt("level") == 2|| PlayerPrefs.GetInt("level") == 4|| PlayerPrefs.GetInt("level") == 5|| PlayerPrefs.GetInt("level") == 7 || PlayerPrefs.GetInt("level") == 8)
        {
            path[0].SetActive(true);
        }
        else if(PlayerPrefs.GetInt("level") == 1|| PlayerPrefs.GetInt("level") == 3|| PlayerPrefs.GetInt("level") == 6 || PlayerPrefs.GetInt("level") == 9)
        {
            path[1].SetActive(true);
        }
    }
    private void OnDisable()
    {
        Event_manager.carDestroy -= Task;
    }
    //this function responsible when car destroyed
    void Task()
    {
        
        destroyTotalCars += 1;
        taskToAchiveText.text = destroyTotalCars.ToString();
        calculateCarCoins = calculateCarCoins + carCoins;
        totalVehicalsDdestroyText.text = calculateCarCoins.ToString();
        totalVehicalsDdestroyText2.text = calculateCarCoins.ToString();
        showCoins.text = carCoins.ToString();
        showCoinVisual.SetActive(true);
        //Debug.Log(calculateCarCoins);
        Invoke("HideCoinsVisual", 1);
     }
    void Start()
    {
        Invoke("start_cinematic", 13.5f);
        taskTotalText.text = task.ToString();


        //Active heardles with respect to levels
        if (PlayerPrefs.GetInt("level")==0)
        {
            player.playerDamage = 0.09f;
            enableEnemy1.SetActive(true);
            enableHeardels1.SetActive(true);
            enableEnemy2.SetActive(false);
            enableHeardels2.SetActive(false);
            

        }
      else if (PlayerPrefs.GetInt("level") == 1)
        {
            player.playerDamage = 0.1f;
            enableEnemy1.SetActive(false);
            enableHeardels1.SetActive(false);
            enableEnemy2.SetActive(true);
            enableHeardels2.SetActive(true);
        
        }
       else if (PlayerPrefs.GetInt("level") == 2)
        {
            player.playerDamage = 0.12f;
            enableEnemy1.SetActive(true);
            enableHeardels1.SetActive(true);
           // enableEnemy2.SetActive(true);
           // enableHeardels2.SetActive(true);
            
        }
        else if (PlayerPrefs.GetInt("level") == 3)
        {
            player.playerDamage = 0.15f;
            enableEnemy1.SetActive(false);
            enableHeardels1.SetActive(false);
            enableEnemy2.SetActive(true);
            enableHeardels2.SetActive(true);
            
        }
        else if (PlayerPrefs.GetInt("level") == 4)
        {
            player.playerDamage = 0.18f;
            enableEnemy1.SetActive(true);
            enableHeardels1.SetActive(true);
            enableEnemy2.SetActive(false);
            enableHeardels2.SetActive(false);
          
        }
        if (PlayerPrefs.GetInt("level") == 5)
        {
            player.playerDamage = 0.2f;
            enableEnemy1.SetActive(true);
            enableHeardels1.SetActive(true);
            enableEnemy2.SetActive(false);
            enableHeardels2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("level") == 6)
        {
            player.playerDamage = 0.25f;
            enableEnemy1.SetActive(false);
            enableHeardels1.SetActive(false);
            enableEnemy2.SetActive(true);
            enableHeardels2.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("level") == 7)
        {
            player.playerDamage = 0.3f;
            enableEnemy1.SetActive(true);
            enableHeardels1.SetActive(true);
            enableEnemy2.SetActive(true);
            enableHeardels2.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("level") == 8)
        {
            player.playerDamage = 0.35f;
            enableEnemy1.SetActive(true);
            enableHeardels1.SetActive(true);
            enableEnemy2.SetActive(false);
            enableHeardels2.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("level") == 9)
        {
            player.playerDamage = 0.4f;
            enableEnemy1.SetActive(true);
            enableHeardels1.SetActive(true);
            enableEnemy2.SetActive(true);
            enableHeardels2.SetActive(true);

        }
        calculateCarCoins = 0;
        calculateBarrelsCoins = 0;
        calculateCrateCoins = 0;

        finishPoint.SetActive(true);
        playerCamra.SetActive(false);
        cinematicCamraStart.SetActive(true);
        //reset for fail
        totalVehicalsDdestroyText.text = 0.ToString();
        totalDestroyCrate.text = 0.ToString();
        destroyBarrelsText.text = 0.ToString();
        totalCoinsText.text = 0.ToString();
      
        //reset for complete
        totalVehicalsDdestroyText2.text = 0.ToString();
        totalDestroyCrate2.text = 0.ToString();
        destroyBarrelsText2.text = 0.ToString();
        totalCoinsText2.text = 0.ToString();
        levelReward.text = PlayerPrefs.GetInt("reward").ToString();

        //tick.gameObject.SetActive(false);
        destroyTotalCars = 0;
        destroyTotalBarrals = 0;
        destroyTotalCrate = 0;
        //Seat player spawn position
        player.transform.position = playerSpawnPosition.position;
        player.transform.rotation = playerSpawnPosition.rotation;
        //Seat enemy spawn position
        for (int i=0;i<enemySpawnPosition.Length;i++)
        {
            allEnemysCars[i].transform.position = enemySpawnPosition[i].position;
            allEnemysCars[i].transform.rotation = enemySpawnPosition[i].rotation;
        }   
    }
    void Update()
    {
        //When Task Complete and player complete the finish line
       if(destroyTotalCars>= task)
        {

            taskBackground.color = Color.green;
            if(player.crossFinishLine == true)
            {
               // totalCoinsText2.text = (calculateBarrelsCoins + calculateCarCoins+calculateCrateCoins).ToString();
                PlayerPrefs.SetInt("Coins", calculateBarrelsCoins + calculateCarCoins + calculateCrateCoins);
                Debug.Log("totalcoins on complete coins" + PlayerPrefs.GetInt("Coins"));
                Enable_ending_cinematic();
            }

            
        }
       //When Task Fail and player cross the finish line
       else if(destroyTotalCars<= task)
        {
            if (player.crossFinishLine == true)
            {
                totalCoinsText.text = (calculateBarrelsCoins + calculateCarCoins + calculateCrateCoins).ToString();
                PlayerPrefs.SetInt("Coins", calculateBarrelsCoins + calculateCarCoins + calculateCrateCoins);
                Debug.Log("totalcoins on fails coins" + PlayerPrefs.GetInt("Coins"));
                Game_controller.instance.Main_Manue("fail");

            }
        }
       //when player is wasted
       if(player.wasted==true)
        {
            Invoke("MissionFail", 3f);
        }
        //Active second wave of enemys for level 1
        if (PlayerPrefs.GetInt("level") == 0 || PlayerPrefs.GetInt("level") == 5)
        {
           // Debug.Log("active level 1 second wave");
            //if (!allEnemysCars[0].activeInHierarchy && player.reachBool == true)
            //{
            //    allEnemysCars[2].SetActive(true);
            //}
            //if (!allEnemysCars[1].activeInHierarchy && player.reachBool == true)
            //{
            //    allEnemysCars[3].SetActive(true);
            //}
        }
        //Active second wave of enemys for level 2
        if (PlayerPrefs.GetInt("level") == 1 || PlayerPrefs.GetInt("level") == 6)
        {
            Debug.Log("active level 2 second wave");
            //if (!allEnemysCars[0].activeInHierarchy && player.reachBool == true)
            //{
            //    allEnemysCars[3].SetActive(true);
            //}
            //if (!allEnemysCars[1].activeInHierarchy && player.reachBool == true)
            //{
            //    allEnemysCars[4].SetActive(true);
            //}
        }
        //Active second wave of enemys for level 3
        if (PlayerPrefs.GetInt("level") == 2 || PlayerPrefs.GetInt("level") == 7)
        {
            Debug.Log("active level 2 second wave");
            if (player.reachBool2 == true)
            {
                path[0].SetActive(false);
                path[1].SetActive(true);
                level3FinishPoint.SetActive(true);
                Invoke(nameof(EnabEnemy),1f);
            }
            if(player.reachBool==true)
            {
                for (int i = allEnemysCars.Length / 2; i < allEnemysCars.Length; i++)
                {
                    allEnemysCars[i].GetComponent<RCC_AICarController>().enabled = true;
                    allEnemysCars[i].GetComponent<Enemy_controller>().enabled = true;
                }
            }
        }

        //Active second wave of enemys for level 4
        if (PlayerPrefs.GetInt("level") == 3 || PlayerPrefs.GetInt("level") == 8)
        {
            Debug.Log("active level 2 second wave");
            //if (!allEnemysCars[0].activeInHierarchy && player.reachBool == true)
            //{
            //    allEnemysCars[3].SetActive(true);
            //}
            //if (!allEnemysCars[1].activeInHierarchy && player.reachBool == true)
            //{
            //    allEnemysCars[4].SetActive(true);
            //}
        }
        //Active second wave of enemys for level 5
        if (PlayerPrefs.GetInt("level") == 4|| PlayerPrefs.GetInt("level") == 9)
        {
            Debug.Log("active level 1 second wave");
            //if (!allEnemysCars[0].activeInHierarchy && player.reachBool == true)
            //{
            //    allEnemysCars[2].SetActive(true);
            //}
            //if (!allEnemysCars[1].activeInHierarchy && player.reachBool == true)
            //{
            //    allEnemysCars[3].SetActive(true);
            //}
        }
        
       
        //Calculate mony from barrels
        for (int i = 0; i < allBarrels.Length; i++)
        {
            if (allBarrels[i].GetComponent<Hardals>().isDestroyed == true)
            {
                calculateBarrelsCoins = calculateBarrelsCoins + BarrelCoins;
                destroyBarrelsText.text = calculateBarrelsCoins.ToString();
                destroyBarrelsText2.text = calculateBarrelsCoins.ToString();
               // Debug.Log("barrels coins" + calculateBarrelsCoins);
                showCoins.text = BarrelCoins.ToString();
                showCoinVisual.SetActive(true);
                Invoke("HideCoinsVisual", 1);
            }
        }
        //Calculate mony from crate
        for (int i = 0; i < allCrate.Length; i++)
        {
            if (allCrate[i].GetComponent<Coin>().isDestroyed == true)
            {
                calculateCrateCoins = calculateCrateCoins + crateCoins;
                totalDestroyCrate.text = calculateCrateCoins.ToString();
                totalDestroyCrate2.text = calculateCrateCoins.ToString();
              //  Debug.Log("Create coins"+calculateCrateCoins);
                showCoinsOnCreate.text = BarrelCoins.ToString();
                showCoinVisualOnCreate.SetActive(true);
                Invoke("HideCoinsVisualOnCreate", 1);
            }
        }
      
        
        
        //for just Combine level
        //if (PlayerPrefs.GetInt("level") == 2|| PlayerPrefs.GetInt("level") == 7)
        //{
        //    if(player.reachBool2 == true)
        //    {
        //        for (int i = allEnemysCars.Length / 2; i < allEnemysCars.Length; i++)
        //        {
        //            Debug.Log("active second level cars ");
        //            allEnemysCars[i].GetComponent<RCC_AICarController>().enabled = true;
        //            allEnemysCars[i].GetComponent<Enemy_controller>().enabled = true;
        //        }
        //    }
        //}
    }
    public void EnabEnemy()
    {
        enableEnemy2.SetActive(true);
        enableHeardels2.SetActive(true);
        finishPoint.SetActive(false);
    }
    public void start_cinematic()
    {
        cinematicCamraStart.SetActive(false);
        playerCamra.SetActive(true);
        Game_controller.instance.startPanel.SetActive(true);
        Invoke("Start_Wait", startWait);
        Invoke("EnableEnemyCarsMovement", startWait);
    }
    public void Start_Wait()
    {
       // Debug.Log("start");
        Invoke("hidestartpanel", 0.5f);
        Game_controller.instance.gamePlayManue.SetActive(true);
    }
    public void EnableEnemyCarsMovement()
    {
        // Activat Enemys

        if(PlayerPrefs.GetInt("level") == 0 || PlayerPrefs.GetInt("level") == 1|| PlayerPrefs.GetInt("level") == 3 || PlayerPrefs.GetInt("level") == 4||PlayerPrefs.GetInt("level") == 5 || PlayerPrefs.GetInt("level") == 6 || PlayerPrefs.GetInt("level") == 8 || PlayerPrefs.GetInt("level") == 9)
        {
            foreach (GameObject Enemy in allEnemysCars)
            {
                Enemy.GetComponent<RCC_AICarController>().enabled = true;
                Enemy.GetComponent<Enemy_controller>().enabled = true;
            }
        }
       else if(PlayerPrefs.GetInt("level") == 2|| PlayerPrefs.GetInt("level") == 7)
        {
            Debug.LogError("for level 3");
            for (int i=0;i<allEnemysCars.Length/2;i++)
            {
                allEnemysCars[i].GetComponent<RCC_AICarController>().enabled = true;
                allEnemysCars[i].GetComponent<Enemy_controller>().enabled = true;
            }
        }
       
    }
  
    public void hidestartpanel()
    {
        Game_controller.instance.startPanel.SetActive(false);
    }
 
   public void HideCoinsVisual()
    {
        showCoinVisual.SetActive(false);
        
    }
    public void HideCoinsVisualOnCreate()
    {
        
        showCoinVisualOnCreate.SetActive(false);
    }
    public void Enable_ending_cinematic()
    {
        Game_controller.instance.victoryStage.SetActive(true);
        Game_controller.instance.gamePlayManue.SetActive(false);
        playerCamra.SetActive(false);
        cinematicCamraStart.SetActive(false);
        cinematicCamraVictory.SetActive(true);
        Invoke("Enable_complete_panel", 16f);
    }
    public void Enable_complete_panel()
    {
        Game_controller.instance.Main_Manue("complete");
        
          if(PlayerPrefs.GetInt("removeads")==0)
          {
            //AdsManager.Instance.HideBanner();
            UnityAdController.Instance.ShowUnityAd();
         //ConsoliAds.Instance.ShowInterstitial(5);
        //AdsManager.Instance.ShowBanner(5);
          }
    }
    public void MissionFail()
    {
        Time.timeScale = 1f;
        totalCoinsText.text = (calculateBarrelsCoins + calculateCarCoins + calculateCrateCoins).ToString();
        PlayerPrefs.SetInt("Coins", calculateBarrelsCoins + calculateCarCoins + calculateCrateCoins);
        Debug.Log("totalcoins on fails coins" + PlayerPrefs.GetInt("Coins"));
        Game_controller.instance.Main_Manue("fail");
        Debug.LogError("AdCalled on fail");
       /**/

    }
}
