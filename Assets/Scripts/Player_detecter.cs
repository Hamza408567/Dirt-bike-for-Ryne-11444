using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_detecter : MonoBehaviour
{
    public bool fire;
    public Transform leftBulletPosition, rightBulletPosition;
    void Start()
    {
        fire = false;
    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fire = true;
           // Debug.Log("enter in player colider");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            fire = true;

            leftBulletPosition.LookAt(new Vector3(other.gameObject.transform.position.x, leftBulletPosition.transform.position.y, other.gameObject.transform.position.z));
            rightBulletPosition.LookAt(new Vector3(other.gameObject.transform.position.x, rightBulletPosition.transform.position.y, other.gameObject.transform.position.z));
           // Debug.Log("stay in player range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        fire = false;
      //  Debug.Log("exit from player ");
    }
}
