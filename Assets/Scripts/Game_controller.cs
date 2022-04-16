using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_controller : MonoBehaviour
{
    public GameObject[] Levels;
    public bool ready;
    public GameObject gamePlayManue;
    public GameObject startPanel;
    public GameObject pauseManue;
    public GameObject completeManue;
    public GameObject settingManue;
    public GameObject failManue;
    public Button soundButton;
    public Player_controller player;
    public int level;
    public static Game_controller instance;
    public GameObject playerSounds;
    public bool check;
    public GameObject victoryStage;
    public AudioSource clickEffect;
    //Environment attributes
    [Header("Environment Attribute")]
    public GameObject rainVfx,snowEffect;
    public GameObject playerRainVfx,playerSnow;
   //rock material
   // public Material rockMaterial;
   // public Texture rocTexture1, rocTexture2, rocTexture3;
   //tree material
   // public Material treeMaterial;
   // public Texture treeTexture1, treeTexture2, treeTexture3;
    //busheh material
   // public Material bushesMaterial;
   // public Texture bushesTexture1, bushesTexture2, bushesTexture3;
   //ground material
    public Material groundMaterial;
    public Texture groundTexture1, groundTexture2, groundTexture3;
    // fog colour
    public Color fogColor1,fogColor2, fogColor3, fogColor4;
    //light colour
    public Color lightColor1,lightColor2, lightColor3, lightColor4;
    //skybox
    public Material skyBox1, skyBox2, skyBox3, skyBox4;
   //direction light rotation
    public Light directionalLight;
    public bool nitro;
    

    public void NitroDisable()
    {
        Invoke(nameof(Disablen), 1f);
    }
    public void Disablen()
    {
        nitro = false;
    }

    private void Awake()
    {

        instance = this;
    }
    void Start()
    {
        level = PlayerPrefs.GetInt("level");
        PlayerPrefs.SetInt("inapp", 1);
        Time.timeScale = 1f;
        Levels[level].SetActive(true);
        gamePlayManue.SetActive(false);
        check = false;
        //check sound
       

        //set mode
        if(PlayerPrefs.GetInt("ModeSelect")==0)
        {
            groundMaterial.mainTexture = groundTexture2;
        }
        else if(PlayerPrefs.GetInt("ModeSelect") == 1)
        {
            groundMaterial.mainTexture = groundTexture1;
        }  
        else if(PlayerPrefs.GetInt("ModeSelect") == 2)
        {
            groundMaterial.mainTexture = groundTexture3;
        }


        //Set Environment for level
        if (level==0|| level == 5)//green environment
        {
            rainVfx.SetActive(false); playerRainVfx.SetActive(false);
            snowEffect.SetActive(false); playerSnow.SetActive(false);
            RenderSettings.fogColor = fogColor1;
            directionalLight.color = lightColor1;
            directionalLight.transform.rotation = Quaternion.Euler(7, 181, -322);
            RenderSettings.skybox = skyBox1;
        }
        else if (level == 1 || level == 6)//brown environment
        {
            snowEffect.SetActive(false); playerSnow.SetActive(false);
            rainVfx.SetActive(false); playerRainVfx.SetActive(false);
            RenderSettings.fogColor = fogColor2;
            directionalLight.color = lightColor2;
            directionalLight.transform.rotation = Quaternion.Euler(60, 244, 0);
            RenderSettings.skybox = skyBox2;
        }
        else if (level == 2 || level == 7)//green/brown environment
        {
            snowEffect.SetActive(false); playerSnow.SetActive(false);
            rainVfx.SetActive(false); playerRainVfx.SetActive(false);
            RenderSettings.fogColor = fogColor2;
            directionalLight.color = lightColor2;
            directionalLight.transform.rotation = Quaternion.Euler(60, 244, 0);
            RenderSettings.skybox = skyBox2;
        }
        else if (level == 3 || level == 8)//brown environment
        {
            snowEffect.SetActive(false); playerSnow.SetActive(false);
            rainVfx.SetActive(true); playerRainVfx.SetActive(true);
            RenderSettings.fogColor = fogColor3;
            directionalLight.color = lightColor3;
            directionalLight.transform.rotation = Quaternion.Euler(50, -30, 0);
            RenderSettings.skybox = skyBox3;
        }
        else if (level == 4 || level == 9)//brown environment
        {
            snowEffect.SetActive(true); playerSnow.SetActive(true);
            rainVfx.SetActive(false); playerRainVfx.SetActive(false);
            RenderSettings.fogColor = fogColor4;
            directionalLight.color = lightColor4;
            directionalLight.transform.rotation = Quaternion.Euler(60, 244, 0);
            RenderSettings.skybox = skyBox4;
        }
    }


    void Update()
    {
        if(player.wasted==true)
        {
            rainVfx.transform.parent = null;
            snowEffect.transform.parent = null;
        }
    }
    public void Main_Manue(string s)
    {
        if (check == false)
        {
            check = true;
        }
        if (s == "pause")
        {
           
            gamePlayManue.SetActive(false);
            pauseManue.SetActive(true);
            playerSounds.SetActive(false);
            Time.timeScale = 0f;
            clickEffect.Play();

        }
        else if (s == "home")
        {

            Time.timeScale = 1f;
            SceneManager.LoadScene("Main Manue");
            clickEffect.Play();
        }
        else if (s == "retry")
        {

            Time.timeScale = 1f;
            SceneManager.LoadScene("Gameplay");
            clickEffect.Play();
        }
        else if (s == "resume")
        {

            playerSounds.SetActive(true);
            Time.timeScale = 1f;
            gamePlayManue.SetActive(true);
            pauseManue.SetActive(false);
           clickEffect.Play();
        }
        else if (s == "setting")
        {
            settingManue.SetActive(true);
            clickEffect.Play();
        }
        else if (s == "closesetting")
        {
           
            settingManue.SetActive(false);
            clickEffect.Play();
        }
        else if (s == "exit")
        {
            Application.Quit();
            clickEffect.Play();
        }
        else if (s == "next")
        {

            PlayerPrefs.SetInt("nextlevel", 1);
            SceneManager.LoadScene("Main Manue");
            clickEffect.Play();
        }
        else if (s == "collect")
        {
            clickEffect.Play();
        }
        else if (s == "complete")
        {
            
            Time.timeScale = 0f;
            completeManue.SetActive(true);
            gamePlayManue.SetActive(false);
            playerSounds.SetActive(false);
            clickEffect.Play();

        }
        else if (s == "fail")
        {
            
            Time.timeScale = 0f;
            gamePlayManue.SetActive(false);
            failManue.SetActive(true);
            clickEffect.Play();
           
        }
    }
    public void Sound()
    {
        clickEffect.Play();
        if (PlayerPrefs.GetInt("sound")==1)
        {
            AudioListener.pause = false;
            PlayerPrefs.SetInt("sound", 0);
            //soundButton.colors = Color.red;
        }
        else if(PlayerPrefs.GetInt("sound") == 0)
        {
            AudioListener.pause = true;
            PlayerPrefs.SetInt("sound", 1);
        }
        
    }
}
