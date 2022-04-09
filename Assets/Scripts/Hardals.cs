using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hardals : MonoBehaviour
{
    public Image healthBar;
    public GameObject explosion;
    public Enemy_detecter enemyDetector;
    public bool isDestroyed;
    public GameObject barral, HB;
    public bool check;
    private void Start()
    {
        check = false;
        isDestroyed = false;
    }
    private void Update()
    {
        if (healthBar.fillAmount == 1)
        {
            isDestroyed = false;
            if (check == false)
            {
                barral.SetActive(false);
                HB.SetActive(false);
                //Debug.Log("explod barral");
                explosion.SetActive(true);
                enemyDetector.fire = false;
                this.gameObject.tag = "Untagged";
                Invoke("Hide_Object", 1f);
                check = true;
                isDestroyed = true;
            }
        }
        }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            healthBar.fillAmount += 0.5f;
            // Debug.Log("bullet hit trigger");
        }
    }
    public void Hide_Object()
    {
        gameObject.SetActive(false);
    }
}
