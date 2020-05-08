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
            
            if (gun != null) {
                gun.GetComponent<Shoot>().FillAmmo();
                Destroy(gameObject);
            }
        }
    }
}
