using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public Rigidbody rb;
 
    void Start()
    {

        // Vector3 direction = new Vector3(-10f, 10f, 0.0f);
        // rb.AddForce(Vector3.forward * 10);
        rb.AddForce(0, 100, 0);
        rb.AddForce(50,0,0);
        Destroy(transform.gameObject, 2f);
        //this.GetComponent<AudioSource>().enabled = true;
        // Invoke("bulletSound", 0.5f);

    }

    public void bulletSound()
    {
        this.GetComponent<AudioSource>().enabled = true;
    }

}
