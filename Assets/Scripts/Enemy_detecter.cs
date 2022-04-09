using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy_detecter : MonoBehaviour
{
    public float minX, maxX;
    public bool fire;
    public Transform leftBulletPosition, rightBulletPosition;
    public Transform DefaultLeftPosition,DefaultRightPosition;
    public void ManualShoot(bool temp)
    {
      fire = temp;
    }
    void Start()
    {
        fire = false;
    }

 
    void Update()
    {
        if(fire==false)
        {
            leftBulletPosition.rotation = DefaultLeftPosition.rotation;
            rightBulletPosition.rotation = DefaultRightPosition.rotation;
           // Debug.LogError("reset shoot position");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            fire = true;
           
        }
        else if (other.gameObject.CompareTag("hardal"))
        {
            fire = true;
          
        }
        else if (other.gameObject.CompareTag("coin"))
        {
            fire = true;
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
           
                fire = true;
            leftBulletPosition.LookAt(new Vector3(other.gameObject.transform.position.x, leftBulletPosition.transform.position.y, other.gameObject.transform.position.z));
            rightBulletPosition.LookAt(new Vector3(other.gameObject.transform.position.x, rightBulletPosition.transform.position.y, other.gameObject.transform.position.z));
           // leftBulletPosition.transform.eulerAngles = new Vector3(transform.rotation.x, Mathf.Clamp(transform.eulerAngles.y, minX, maxX), transform.rotation.z);
           // rightBulletPosition.transform.eulerAngles = new Vector3(transform.rotation.x, Mathf.Clamp(transform.eulerAngles.y, minX, maxX), transform.rotation.z);
            
        }
        else if (other.gameObject.CompareTag("hardal"))
        {
            fire = true;
           
            leftBulletPosition.LookAt(new Vector3(other.gameObject.transform.position.x, leftBulletPosition.transform.position.y, other.gameObject.transform.position.z));
            rightBulletPosition.LookAt(new Vector3(other.gameObject.transform.position.x, rightBulletPosition.transform.position.y, other.gameObject.transform.position.z));
        }
        else if (other.gameObject.CompareTag("coin"))
        {
            fire = true;

            leftBulletPosition.LookAt(new Vector3(other.gameObject.transform.position.x, leftBulletPosition.transform.position.y, other.gameObject.transform.position.z));
            rightBulletPosition.LookAt(new Vector3(other.gameObject.transform.position.x, rightBulletPosition.transform.position.y, other.gameObject.transform.position.z));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            fire = false;
      
        }
        else if (other.gameObject.CompareTag("hardal"))
        {
            fire = false;
            
        }
        else if (other.gameObject.CompareTag("coin"))
        {
            fire = false;

        }
    }
}
