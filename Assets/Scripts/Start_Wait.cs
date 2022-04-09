using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Wait : MonoBehaviour
{
    public static Start_Wait instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    public void wait()
    {
        this.gameObject.SetActive(true);
    }
}
