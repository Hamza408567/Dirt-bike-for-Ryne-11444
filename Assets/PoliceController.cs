using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{  
    public GameObject[] police_car;
    public static PoliceController instance;
    public int policedetectionRang;
    public float catchspeed, detectspeed;
    public bool wheelerDetected, detectionRange;
    public bool playerCatchRange;
    public int countOutRangeCar,countOutRangeCatchCar;

    public float fireRate;
    public float nextFire;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        checkPlayerNotInRange();
    }


    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            checkPlayerNotInRange();
        }
        DetectiveBar();
        catchBar();
    }
    public void catchBar()
    {
        if (playerCatchRange)
        {
            Game_controller.instance.healthBar.fillAmount = Mathf.Lerp(Game_controller.instance.healthBar.fillAmount, 1.1f, Time.deltaTime * catchspeed);
            if (Game_controller.instance.healthBar.fillAmount >= 1)
            {
                PlayerCatch();
            }
        }
        else
        {
            Game_controller.instance.healthBar.fillAmount = Mathf.Lerp(Game_controller.instance.healthBar.fillAmount, 0, Time.deltaTime * catchspeed);
        }
    }
    public void DetectiveBar()
    {
        if (Game_controller.instance.wheels && detectionRange)
        {
            Game_controller.instance.policeDetectBar.fillAmount = Mathf.Lerp(Game_controller.instance.policeDetectBar.fillAmount, 1.1f, Time.deltaTime * detectspeed);
        }
        if(!detectionRange)
        {
            Game_controller.instance.policeDetectBar.fillAmount = Mathf.Lerp(Game_controller.instance.policeDetectBar.fillAmount, 0f, Time.deltaTime * detectspeed);
        }
        }
    public void PlayerCatch()
    {
        Time.timeScale = 0;
        Game_controller.instance.playerCatchPanel.SetActive(true);
    }

    public void checkPlayerNotInRange()
    {

        countOutRangeCar = 0;
        countOutRangeCatchCar=0;
        for (int i = 0; i < police_car.Length; i++)
        {
            if (!police_car[i].GetComponent<PoliceCar>().detectionrange)
            {
                countOutRangeCar++;
            }
            if(!police_car[i].GetComponent<PoliceCar>().playercatchrange)
            {
                countOutRangeCatchCar++;
            }
        }

        if (countOutRangeCar == police_car.Length)
        {
            detectionRange = false;
        }
        else
        {
            detectionRange = true;
        }
        if(countOutRangeCatchCar==police_car.Length)
        {
            playerCatchRange = false;
        }
        else
        {
            playerCatchRange = true;
        }
        Debug.LogError("recursion");
    }

}

