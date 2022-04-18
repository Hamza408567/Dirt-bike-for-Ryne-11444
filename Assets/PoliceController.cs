using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    public bool playerInRange;
    public static PoliceController instance;
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
            Game_controller.instance.healthBar.fillAmount = Mathf.Lerp(Game_controller.instance.healthBar.fillAmount, 1.1f, 0.01f);
            if (Game_controller.instance.healthBar.fillAmount >= 1)
            {
               PlayerCatch();
            }
        }
        else
        {
            Game_controller.instance.healthBar.fillAmount = Mathf.Lerp(Game_controller.instance.healthBar.fillAmount, 0, 0.03f);
        }
        
    }

    public void PlayerCatch()
    {

    }
}
