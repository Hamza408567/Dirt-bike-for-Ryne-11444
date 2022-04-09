using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOWunity : MonoBehaviour
{
    private void OnEnable()
    {
        UnityAdController.Instance.ShowUnityAd();
    }
}
