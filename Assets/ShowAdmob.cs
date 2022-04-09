using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdmob : MonoBehaviour
{
    private void OnEnable()
    {
        GoogleMobileAdsDemoScript.showInter = true;
    }
}
