using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform playerSpawnPoint;

    public void Start()
    {
        Game_controller.instance.player.transform.position = playerSpawnPoint.position;
        Game_controller.instance.player.transform.rotation = playerSpawnPoint.rotation;
        Game_controller.instance.gamePlayManue.SetActive(true);
    }
}
