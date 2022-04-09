using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NItroEnable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Game_controller.instance.nitro = true;
            Game_controller.instance.NitroDisable();
            transform.gameObject.SetActive(false);
        }
    }
}
