using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    //public Rigidbody rb;
    public int speed;
    public GameObject bullet;
    public GameObject explosion;
    public float enableAterTime;
    public bool stop;

    private void Start()
    {
        stop = true;
    }
    void Update()
    {
        if (!bullet.activeInHierarchy)
        {
            return;
        }
        else
        {
            if (stop == true)
            {
                this.transform.Translate(Vector3.forward * speed);
                explosion.transform.position = transform.position;
            }

        }
        // rb.velocity = transform.forward * speed;

    }
    private void OnEnable()
    {
        stop = true;
    }
    private void OnTriggerEnter(Collider other)
    {
       // Debug.LogError("trigger");
        if (other.CompareTag ( "enemy"))
        {
            stop = false;

            explosion.transform.position = transform.position;
            bullet.SetActive(false);
            explosion.SetActive(true);
            Invoke("EnableBullet", enableAterTime);

        }
        else if (other.gameObject.layer == 8)
        {
            stop = false;

          //  Debug.LogError("ground");
            explosion.transform.position = transform.position;
            bullet.SetActive(false);
            explosion.SetActive(true);
            Invoke("EnableBullet", enableAterTime);
        }
        else if (other.CompareTag("hardal"))
        {
            stop = false;

            explosion.transform.position = transform.position;
            bullet.SetActive(false);
            explosion.SetActive(true);
            Invoke("EnableBullet", enableAterTime);

        }
        else if (other.CompareTag("coin"))
        {
            stop = false;
            explosion.transform.position = transform.position;
            bullet.SetActive(false);
            explosion.SetActive(true);
            Invoke("EnableBullet", enableAterTime);

        }
    }
    public void EnableBullet()
    {
       // bullet.SetActive(true);
        explosion.SetActive(false);
        //this.gameObject.SetActive(false);
    }
}
