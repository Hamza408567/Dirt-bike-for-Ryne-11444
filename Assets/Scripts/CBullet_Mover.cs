using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet_Mover : MonoBehaviour
{

    public int speed;

    void Update()
    {
        this.transform.Translate(Vector3.forward * speed);
        //explosion.transform.position = transform.position;
        Destroy(this.gameObject, 1f);
    }
}
