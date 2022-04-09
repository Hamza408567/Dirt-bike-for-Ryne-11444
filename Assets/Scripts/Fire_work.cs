using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_work : MonoBehaviour
{
    public GameObject fireWork1;
    public GameObject[] confiti;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Invoke("First", 0.5f);
            Invoke("Second", 1f);
            Invoke("Third", 1.7f);
        }
    }
    public void First()
    {
      //  Debug.Log("FIRST");
        fireWork1.SetActive(true);
        confiti[0].SetActive(true);
        confiti[1].SetActive(true);

    }
    public void Second()
    {
       // Debug.Log("sECOND");
        confiti[2].SetActive(true);
        confiti[3].SetActive(true);
        
        
    }
    public void Third()
    {
       // Debug.Log("Third");
        confiti[4].SetActive(true);
        confiti[5].SetActive(true);


    }
}
