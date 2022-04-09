using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_shoot_enemy : MonoBehaviour
{
    public Transform bulletposition, shellPosition;
    public GameObject[] bullet;
    public GameObject bulletRef;
   // public GameObject shell;
    public int bulletRange;
    public GameObject GunSpin;
    public GameObject muzzelFlash;
    public int rotatespeed;
    public Player_detecter playerDetector;
    public float fireRate;
    public float nextFire;
    public bool gunsActive;
    public int gunActiveWait;
    private bool firstTime;
    private void Start()
    {
       // Time.timeScale = 0.1f;
        gunsActive = false;
        Invoke("GunsActivate", gunActiveWait);
        firstTime = true;
        for(int i=0;i<bullet.Length; i++)
        {
            bullet[i] = Instantiate(bulletRef, bulletposition.transform.position, bulletposition.transform.rotation);
          //  Debug.LogError("instantiate all bullets");
        }

        }
    private void Update()
    {
        //set initial point and set position after disble
        for (int i = 0; i < bullet.Length; i++)
        {
              if (!bullet[i].activeInHierarchy && bullet[i].transform.position != bulletposition.position)
              {
            bullet[i].transform.position = bulletposition.position;
            bullet[i].transform.rotation = bulletposition.rotation;
              }
        }
        if (gunsActive == true)
        {
            //if (firstTime == false)
            //{
               
            //}
            if (playerDetector.fire == true)
            {
                muzzelFlash.SetActive(true);
            }
            else
            {
                muzzelFlash.SetActive(false);
            }
            if (playerDetector.fire == true)
            {
                // Debug.Log("detect enemy");
                GunSpin.transform.rotation *= Quaternion.Euler(0, 0, rotatespeed * Time.deltaTime);

                //add delay in firing
                if (Time.time > nextFire)
                {
                    for (int i = 0; i < bullet.Length; i++)
                    {
                        //check which bulet are in there orignal position

                        if (Vector3.Distance(bullet[i].transform.position, bulletposition.position) <= 1)
                        {
                            //shooting
                            if (!bullet[i].transform.GetChild(0).gameObject.activeInHierarchy)
                            {
                                bullet[i].transform.GetChild(0).gameObject.SetActive(true);
                            }
                           // Debug.LogError(bullet[1]);
                            bullet[i].SetActive(true);
                            nextFire = Time.time + fireRate;
                            StartCoroutine(HideBullet(i));
                            return;
                        }

                    }
                }


            }
        }
    }
    public void GunsActivate()
    {
        gunsActive = true;
    }
    IEnumerator HideBullet(int a)
    {
        yield return new WaitForSeconds(bulletRange);
        if (bullet[a].activeInHierarchy)
        {
            bullet[a].SetActive(false);
           // bullet[a].transform.position = bulletposition.position;
           // bullet[a].transform.rotation = bulletposition.rotation;
            // shell[a].SetActive(false);

        }

    }
}
