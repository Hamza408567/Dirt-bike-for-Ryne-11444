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
        if (Cars[1].activeInHierarchy)
        {
            if (Cars[1].GetComponentInChildren<Enemy_controller>().destroy == true)
            {
                if (carDestroy != null)
                    carDestroy();
            }
        }
        if (Cars[2].activeInHierarchy)
        {
            if (Cars[2].GetComponentInChildren<Enemy_controller>().destroy == true)
            {
                if (carDestroy != null)
                    carDestroy();
            }
        }
        if (Cars[3].activeInHierarchy)
        {
            if (Cars[3].GetComponentInChildren<Enemy_controller>().destroy == true)
            {
                if (carDestroy != null)
                    carDestroy();
            }
        }
        if (Cars[4].activeInHierarchy)
        {
            if (Cars[4].GetComponentInChildren<Enemy_controller>().destroy == true)
            {
                if (carDestroy != null)
                    carDestroy();
            }
        }
        if (Cars[5].activeInHierarchy)
        {
            if (Cars[5].GetComponentInChildren<Enemy_controller>().destroy == true)
            {
                if (carDestroy != null)
                    carDestroy();
            }
        }
        if (Cars[6].activeInHierarchy)
        {
            if (Cars[6].GetComponentInChildren<Enemy_controller>().destroy == true)
            {
                if (carDestroy != null)
                    carDestroy();
            }
        }
        if (Cars[7].activeInHierarchy)
        {
            if (Cars[7].GetComponentInChildren<Enemy_controller>().destroy == true)
            {
                if (carDestroy != null)
                    carDestroy();
            }
        }
        if (Cars[8].activeInHierarchy)
        {
            if (Cars[8].GetComponentInChildren<Enemy_controller>().destroy == true)
            {
                if (carDestroy != null)
                    carDestroy();
            }
        }
        if (Cars[9].activeInHierarchy)
        {
            if (Cars[9].GetComponentInChildren<Enemy_controller>().destroy == true)
            {
                if (carDestroy != null)
                    carDestroy();
            }
        }
    }
}
 