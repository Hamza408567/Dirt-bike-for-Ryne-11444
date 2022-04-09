using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    private void Awake()
    {
        transform.gameObject.SetActive(false);
        Invoke("StartWait", 6f);
    }
    void Start()
    {
       
    }

   public void StartWait()
    {
        transform.gameObject.SetActive(true);
    }
   
}
