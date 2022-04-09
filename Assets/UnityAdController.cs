using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdController : MonoBehaviour
{
    [SerializeField] private string unityAdID = "3836011";

    [SerializeField] private bool enableTestMode = false;

    public static UnityAdController Instance;


    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(this);
        Instance = this;
    }
    private void Start()
    {
        Advertisement.Initialize(unityAdID, enableTestMode);

    }

    public void ShowUnityAd()
    {
      
            if (Advertisement.IsReady("video"))
            {
                Advertisement.Show("video");
            }
        

    }
}

