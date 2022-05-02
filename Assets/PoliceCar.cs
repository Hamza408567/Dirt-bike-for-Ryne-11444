using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    public GameObject target;
    public GameObject policeLights;
    public int catchDistance=10;
   
    
    void Start()
    {
       
        target = Game_controller.instance.player;
    }


    void Update()
    {
        if(Vector3.Distance(target.transform.position,gameObject.transform.position)<= catchDistance)
        {
           PoliceController.instance. playerInRange = true;
        }
        else
        {
            PoliceController.instance.playerInRange = false;
        }
        detectWheelers();
    }
 
    
    public void detectWheelers()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < 50 && Game_controller.instance.wheels)
        {
            PoliceController.instance.DetectionBar();
            if (Game_controller.instance.policeDetectBar.fillAmount >= 1)
            {
                policeLights.SetActive(true);
               PoliceController.instance. wheelerDetected = true;
                GetComponent<RCC_AICarController>().SetTarget("catchPlayer");
            }
        }
        else
        {
            GetComponent<RCC_AICarController>().SetTarget("");
        }
    }
}
