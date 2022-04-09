using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public Image healthBar;
    public GameObject explosion;
    public Enemy_detecter enemyDetector;
    public bool isDestroyed;
    public GameObject create,glow;
    public bool check;
    public bool health;
    private void Start()
    {
        health = false;
        check = false;
        isDestroyed = false;
    }
    private void Update()
    {
        //this.gameObject.transform.rotation *= Quaternion.Euler(0, 0, -850 * Time.deltaTime);
        if (health == true)
        {
            isDestroyed = false;
            if (check == false)
            {
                create.SetActive(false);
                glow.SetActive(false);
              
                //Debug.Log("explod barral");
                explosion.SetActive(true);
                enemyDetector.fire = false;
                this.gameObject.tag = "Untagged";
                Invoke("Hide_Object", 3f);
                check = true;
                isDestroyed = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            health = true;
          //   Debug.Log("coin hit trigger");
        }
    }
    public void Hide_Object()
    {
        gameObject.SetActive(false);
    }
}
