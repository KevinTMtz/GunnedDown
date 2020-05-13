using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillAmmo : MonoBehaviour
{
    private GunsInventory gunsInventory;
    
    // Start is called before the first frame update
    void Start()
    {
        gunsInventory = FindObjectOfType<GunsInventory>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            GameObject gun = gunsInventory.GetActiveWeapon();
            Shoot gunShoot = gun.GetComponent<Shoot>();
            
            if (gun != null && gunShoot.AbleToRefill) {
                gunShoot.FillAmmo();
                Destroy(gameObject);
            }
        }
    }
}
