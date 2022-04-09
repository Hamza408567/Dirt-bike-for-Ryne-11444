using SWS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_controller : MonoBehaviour
{
    public Image bar;
    public GameObject body;
    public Player_detecter playerDetector;
    public Enemy_detecter enemyDetector;
    public GameObject explosion;
    public Rigidbody rb;
    private bool check;
    public GameObject[] hideAllObjects;
    public Material RustedMaterial;
    public GameObject wheelPartical;
    public bool destroy;
    void Start() 
    {
        
        destroy = false;
        check = false;
        bar.fillAmount += 0.0f;
        rb = transform.gameObject.GetComponent<Rigidbody>();
        wheelPartical.SetActive(true);
       
    }

    
    void Update()
    {
       
       if (bar.fillAmount==1)
        {
            destroy = false;
            explosion.transform.position = transform.position;
            if(check ==false)
            {
                this.GetComponent<RCC_CarControllerV3>().enabled = false;
                this.GetComponent<RCC_AICarController>().enabled = false;
                body.transform.gameObject.tag = "Untagged";
                body.gameObject.layer = 9;
                body.GetComponent<MeshRenderer>().material = RustedMaterial;
                for(int i=0;i<hideAllObjects.Length;i++)
                {
                    hideAllObjects[i].SetActive(false);
                }
                destroy = true;
                playerDetector.fire = false;
                enemyDetector.fire = false;
                Instantiate(explosion,this. transform.position,this. transform.rotation);
                rb.AddForce(0, 100000*10, 0);
                rb.AddForce(0,0 , 100000 * 5);
                rb.AddTorque(100000 * 5, 0, 0);
                check = true;
                Invoke("Hide_Object",10f);
                wheelPartical.SetActive(false);
                this.gameObject.tag = "Untagged";
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("bullet") )
        {
            bar.fillAmount += 0.01f;
            // Debug.Log("bullet hit trigger");
        }
    }
    public void Hide_Object()
    {
        gameObject.SetActive(false);
    }
    public void Time_Reset()
    {
        Debug.Log("time reset");
        Time.timeScale = 1f;
    }

}
