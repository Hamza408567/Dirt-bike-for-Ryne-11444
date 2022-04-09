using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Auto_Shoot : MonoBehaviour
{
    public Transform bulletposition,shellPosition;
    public GameObject[] bullet;
    public GameObject shell;
    public int bulletRange;
    public GameObject GunSpin;
    public GameObject muzzelFlash;
    public int rotatespeed;
    public Enemy_detecter enemyDetecter;
    public float fireRate;
    public float nextFire;
    public bool firstTime;
    public GameObject bulletRef;

  
    // public AudioClip fireSound;
    private void Start()
    {
        firstTime = true;
        for (int i = 0; i < bullet.Length; i++)
        {
            bullet[i] = Instantiate(bulletRef, bulletposition.transform.position, bulletposition.transform.rotation);
           // Debug.LogError("instantiate all bullets");
        }
    }
    private void Update()
    {
        //set initial point
      
       
        for (int i = 0; i < bullet.Length; i++)
        {
            if (!bullet[i].activeInHierarchy && bullet[i].transform.position != bulletposition.position)
            {
               // Debug.Log("position set");
                bullet[i].transform.position = bulletposition.position;
                bullet[i].transform.rotation = bulletposition.rotation;
               
               
            }
        }

       if (enemyDetecter.fire == true || Input.GetKey("q"))
        {
            muzzelFlash.SetActive(true);
       }
        else
        {
            muzzelFlash.SetActive(false);
        }
            if (enemyDetecter.fire == true || Input.GetKey("q"))
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

                       // Debug.Log("bullet enable");
                        if (!bullet[i].transform.GetChild(0).gameObject.activeInHierarchy)
                            bullet[i].transform.GetChild(0).gameObject.SetActive(true);
                        if (SceneManager.GetActiveScene().name == "Main Manue")
                        {
                            bullet[i].GetComponent<AudioSource>().enabled = false;
                        }
                        bullet[i].SetActive(true);
                        Instantiate(shell, shellPosition.position, shellPosition.rotation);
                       // shell[i].SetActive(true);
                        nextFire = Time.time + fireRate;

                        StartCoroutine(HideBullet(i));
                        return;
                    }

                }
            }
           

        }
    }

    IEnumerator HideBullet(int a)
    {
        yield return new WaitForSeconds(bulletRange);
        if (bullet[a].activeInHierarchy)
        {
            bullet[a].SetActive(false);
           // shell[a].SetActive(false);

        }

    }
}
