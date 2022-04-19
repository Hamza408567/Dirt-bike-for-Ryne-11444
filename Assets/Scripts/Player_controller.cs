using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerSwitchThing
{
    public GameObject target, bikerMan;
    public GameObject[] CameraView;
}

public class Player_controller : MonoBehaviour
{
    public bool death;
    public bool wasted, check;
    public Image hitEffect;
    public GameObject bikeFire;
    public BikeAnimation bikeAnimation;
    public float playerDamage;
    [HideInInspector]
    public Rigidbody rb;
    [Header("Player Select")]
    [Space(10)]
    public GameObject[] character;
    public Avatar[] avatr;
    public Animator animator;
    public PlayerSwitchThing PlayerSwitching;
  
    private void OnEnable()
    {
        animator.avatar = avatr[PlayerPrefs.GetInt(Constants.SelectedCharacter)];
        character[PlayerPrefs.GetInt(Constants.SelectedCharacter)].SetActive(true);
    }
    private void OnDisable()
    {
        for (int i = 0; i < character.Length; i++)
        {
            character[i].SetActive(false);
        }
    }
    private void Start()
    {
     
        rb = transform.gameObject.GetComponent<Rigidbody>();
    }
  
    void Update()
    {
      
       if(Game_controller.instance. healthBar.fillAmount>=0.7f)
        {
            //bikeFire.SetActive(true);
        }
        if (Game_controller.instance.healthBar.fillAmount == 1 && death == true)
        {
            hitEffect.color = new Color(hitEffect.color.r, hitEffect.color.g, hitEffect.color.b, 150f);
            wasted = false;
            if (check == false)
            {
                
                bikeAnimation.Dead();
                wasted = true;
                Debug.Log("explod");
                rb.AddForce(0, 100000 * 5, 0);
                rb.AddTorque(100000 * 15, 100000 * 15, 0);
                check = true;
                this.gameObject.tag = "Untagged";
                Time.timeScale = 0.3f;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemybulet"))
        {
            Game_controller.instance.healthBar.fillAmount += playerDamage;
            hitEffect.color = new Color(hitEffect.color.r, hitEffect.color.g, hitEffect.color.b, 150f*Time.deltaTime*2);
            Invoke("Hide_Blood_vfx", 0.5f);
        }
        if(other.gameObject.CompareTag("coin"))
        {
           
        }
        }
    public void Hide_Blood_vfx()
    {
        hitEffect.color = new Color(hitEffect.color.r, hitEffect.color.g, hitEffect.color.b, 0f* Time.deltaTime*2);
    }
}
