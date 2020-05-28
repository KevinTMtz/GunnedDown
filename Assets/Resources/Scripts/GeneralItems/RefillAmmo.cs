using UnityEngine;

public class RefillAmmo : MonoBehaviour {
    private GunsInventory gunsInventory;
    
    void Start() {
        gunsInventory = FindObjectOfType<GunsInventory>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GameObject gun = gunsInventory.GetActiveWeapon();
            if (gun != null) {
                Shoot gunShoot = gun.GetComponent<Shoot>();
                if (gunShoot.AbleToRefill) {
                    gunShoot.FillAmmo();
                    Destroy(gameObject);
                }
            }
        }
    }
}
