﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    public GameObject target;
    public GameObject policeLights;
    public GameObject policeDecetionArea;
    public ParticleSystem detectionEffect;
    
    public int catchDistance=10;
   
    
    void Start()
    {
       
        target = Game_controller.instance.player;
    }


    void Update()
    {
        if(Vector3.Distance(target.transform.position,gameObject.transform.position)<= catchDistance && PoliceController.instance.wheelerDetected)
        {
           PoliceController.instance. playerInRange = true;
        }
        else
        {
            PoliceController.instance.playerInRange = false;
        }
        detectWheelers();
        PlayerEscape();
    }
 
    
    public void detectWheelers()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < PoliceController.instance.policedetectionRang)
        {
            PoliceController.instance.detectionRange = true;
            if (Game_controller.instance.wheels)
            {
                PoliceController.instance.DetectionBarPositive();
            }
            if (Game_controller.instance.policeDetectBar.fillAmount >= 1)
            {
                detectionEffect.Play();
                PoliceController.instance.policedetectionRang = 100;
                policeDecetionArea.GetComponent<SpriteRenderer>().color = Color.red;
                Vector3 scale = new Vector3(9.4f, 9.4f, 9.4f);
                policeDecetionArea.transform.localScale = scale;
                policeLights.SetActive(true);
                PoliceController.instance.wheelerDetected = true;
               // GetComponent<RCC_AICarController>().SetTarget("catchPlayer");
            }
            else
            {
               // GetComponent<RCC_AICarController>().SetTarget("");
            }
        }
    }
    public void PlayerEscape()
    {
        if(Vector3.Distance(target.transform.position, transform.position) >= PoliceController.instance.policedetectionRang)
        {
            PoliceController.instance.DetectionBarNegative();
            PoliceController.instance.detectionRange = false;
            //GetComponent<RCC_AICarController>().SetTarget("");
            if (Game_controller.instance.policeDetectBar.fillAmount <= 0.01f)
            {
                detectionEffect.Stop();
                PoliceController.instance.policedetectionRang = 50;
                PoliceController.instance.wheelerDetected = false;
                policeDecetionArea.GetComponent<SpriteRenderer>().color = Color.blue;
                Vector3 scale = new Vector3(4.7f, 4.7f, 4.7f);
                policeDecetionArea.transform.localScale = scale;
                policeLights.SetActive(false);
            }

        }
    }
}
