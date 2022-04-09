using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_shell_Left : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {

  
        rb.AddForce(0, 100, 0);
        rb.AddForce(-50, 0, 0);
        Destroy(transform.gameObject, 2f);
        //this.GetComponent<AudioSource>().enabled = true;
        // Invoke("bulletSound", 0.5f);
    }
    public void bulletSound()
    {
        this.GetComponent<AudioSource>().enabled = true;
    }
}
