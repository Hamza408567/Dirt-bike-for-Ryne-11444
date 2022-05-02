using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMap : MonoBehaviour
{
    public Transform player;
    //public Transform playercam;
    void Start()
    {
        player = Game_controller.instance.player.transform;
    }

    
    void LateUpdate()
    {
        Vector3 newposition = player.position;
        newposition.y = transform.position.y;
        transform.position = newposition;
        transform.rotation = Quaternion.Euler(90f, Camera.main.transform.eulerAngles.y, 0f);
    }
}
