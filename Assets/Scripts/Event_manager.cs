using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_manager : MonoBehaviour
{
    
    public delegate void CarDestroy();
    public static event CarDestroy carDestroy;
    [Header("Add all the cars that are using in the game")]
    public GameObject[] Cars;
    public void Update()
    {
        if(Cars[0].activeInHierarchy)
        {
            if(Cars[0].GetComponentInChildren<Enemy_controller>().destroy==true)
            {
                if (carDestroy != null)
                    carDestroy();
            }
        }
    }
}
 