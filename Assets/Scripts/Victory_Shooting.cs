using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory_Shooting : MonoBehaviour
{
    public float fireRate;
    public float nextFire;
    public GameObject cBullet;
    public Transform instentiatePoint;
    public Animator victoryMan;
    public GameObject muzzelFlash;
    private void Start()
    {
      
    }
    private void Update()
    {
        if (victoryMan.GetCurrentAnimatorStateInfo(0).IsTag("gunplay"))
        {
            if (Time.time > nextFire)
            {
                Instantiate(cBullet, instentiatePoint.position, instentiatePoint.rotation);
                muzzelFlash.SetActive(true);
                nextFire = Time.time + fireRate;

            }
        }
        else
        {
            muzzelFlash.SetActive(false);
        }
       
    }
   

}
