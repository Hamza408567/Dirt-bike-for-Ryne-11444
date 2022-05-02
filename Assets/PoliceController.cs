using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    public bool playerInRange;
    public GameObject[] police_car;     
    public static PoliceController instance;
    public float catchspeed,detectspeed;
    public bool wheelerDetected;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        if(playerInRange)
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
    public void DetectionBarPositive()
    {
        Game_controller.instance.policeDetectBar.fillAmount = Mathf.Lerp(Game_controller.instance.policeDetectBar.fillAmount, 1.1f, Time.deltaTime * detectspeed);
    }  
    public void DetectionBarNegative()
    {
        Game_controller.instance.policeDetectBar.fillAmount = Mathf.Lerp(Game_controller.instance.policeDetectBar.fillAmount, 0f, Time.deltaTime * detectspeed);
    }
    public void PlayerCatch()
    {
        Time.timeScale = 0;
        Game_controller.instance.playerCatchPanel.SetActive(true);
    }
}
