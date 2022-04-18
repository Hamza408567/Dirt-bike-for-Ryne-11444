using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    public GameObject target;
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
    }
}
