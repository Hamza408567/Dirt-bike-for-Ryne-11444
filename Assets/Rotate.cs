using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    public bool x, y, z;
    void Start()
    {
        
    }

  
    void Update()
    {
        
        if(x==true)
        {
            transform.Rotate(new Vector3(0, speed, 0), Space.Self);
        } if(y==true)
        {
            transform.Rotate(new Vector3(0, speed, 0), Space.Self);
        } if(z==true)
        {
            //this.transform.rotation *= Quaternion.Euler(0,0, transform.rotation.z+speed);
            transform.Rotate(new Vector3(0, 0, speed), Space.Self);
        }
    }
}
