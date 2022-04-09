using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_move_enemy : MonoBehaviour
{
    //public Rigidbody rb;
    public float speed;
    public GameObject bullet;
    public GameObject explosion;
    public float enableAterTime;

    private void Start()
    {

    }
    void Update()
    {
        if (!bullet.activeInHierarchy)
        {
            return;
        }
        else
        {
            this.transform.Translate(new Vector3(0f, 0f, speed));
            explosion.transform.position = transform.position;
        }
        // rb.velocity = transform.forward * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            return;

        }
        else if (other.CompareTag("Player"))
        {
            // bullet.SetActive(false);
            explosion.transform.position = transform.position;
            bullet.SetActive(false);
            explosion.SetActive(true);
            Invoke("EnableBullet", enableAterTime);

        }
        else if(other.gameObject.layer== 8)
        {
          //  Debug.LogError("ground");
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
