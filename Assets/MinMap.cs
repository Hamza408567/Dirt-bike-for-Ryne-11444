using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMap : MonoBehaviour
{
    public Transform target; 
    void Start()
    {
        target = Game_controller.instance.player.transform;
    }

    
    void LateUpdate()
    {
        Vector3 newposition = target.position;
        newposition.y = transform.position.y;
        transform.position = newposition;
        transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);
    }
}
