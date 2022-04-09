using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_controller : MonoBehaviour
{
    public bool reachBool,reachBool2,reachBool3;
    public bool crossFinishLine;
    public bool death;
    public bool wasted, check;
    public Image healthBar;
    public Image hitEffect;
    public GameObject bikeFire;
    public GameObject guns;
    public BikeAnimation bikeAnimation;
    public Enemy_detecter enemyDetector;
    public float playerDamage;
   // public ControlMode controlMode = ControlMode.simple;
    [HideInInspector]
    public Rigidbody rb;
  
    private void Start()
    {
        if(Application.isEditor)
        {
           // controlMode = ControlMode.simple;
            this.gameObject.GetComponent<BikeControl>().controlMode = ControlMode.simple;
        }
        else
        {
            // controlMode = ControlMode.touch;
            this.gameObject.GetComponent<BikeControl>().controlMode = ControlMode.touch;
        }
        reachBool = false; reachBool2 = false; reachBool3 = false;
        crossFinishLine = false;
        rb = transform.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
       if(healthBar.fillAmount>=0.7f)
        {
            bikeFire.SetActive(true);
        }
        if (healthBar.fillAmount == 1 && death == true)
        {
            hitEffect.color = new Color(hitEffect.color.r, hitEffect.color.g, hitEffect.color.b, 150f);
            wasted = false;
            if (check == false)
            {
                
                bikeAnimation.Dead();
                guns.SetActive(false);
                wasted = true;
                Debug.Log("explod");
                enemyDetector.fire = false;
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
        if(this.gameObject.tag=="Player")
        { 
        if (other.gameObject.CompareTag("reach"))
        {
                 reachBool = true;
        }
        if (other.gameObject.CompareTag("reach2"))
        {
                reachBool2 = true;
        }
        if (other.gameObject.CompareTag("reach3"))
        {
                reachBool3 = true;
        }

            if (other.gameObject.CompareTag("finish"))
        {
            crossFinishLine = true;
        }
        if (other.gameObject.CompareTag("enemybulet"))
        {
            healthBar.fillAmount += playerDamage;
            hitEffect.color = new Color(hitEffect.color.r, hitEffect.color.g, hitEffect.color.b, 150f*Time.deltaTime*2);
            Invoke("Hide_Blood_vfx", 0.5f);
        }
        if(other.gameObject.CompareTag("coin"))
        {
           
        }
        }
    }
    public void Hide_Blood_vfx()
    {
        hitEffect.color = new Color(hitEffect.color.r, hitEffect.color.g, hitEffect.color.b, 0f* Time.deltaTime*2);
    }
}
