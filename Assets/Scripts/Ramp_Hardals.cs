using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp_Hardals : MonoBehaviour
{
    public GameObject obstacle;
    public Transform newPosition;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            obstacle.transform.position = newPosition.position;
        }
    }
}
