using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    BikeCamera bikecamera;

    void Start()
    {
      bikecamera= GetComponent<BikeCamera>();
        bikecamera.target = Game_controller.instance.player.GetComponent<Player_controller>().PlayerSwitching.target.transform;
        bikecamera.BikerMan = Game_controller.instance.player.GetComponent<Player_controller>().PlayerSwitching.bikerMan.transform;
        for (int i = 0; i < bikecamera.cameraSwitchView.Count; i++)
        {
            bikecamera.cameraSwitchView[i] = Game_controller.instance.player.GetComponent<Player_controller>().PlayerSwitching.CameraView[i].transform;
        }
        


    }

}
