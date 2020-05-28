using System.Collections;
using UnityEngine;

public class ActivateForceShield : MonoBehaviour {
    private GameObject forceShield;
    private CapsuleCollider2D bc2d;
    private PlayerHealth playerHealth;
    private bool wait;
    
    void Start() {
        forceShield = Resources.Load<GameObject>("Prefabs/PlayerAbilities/ForceShield");
        bc2d = GetComponent<CapsuleCollider2D>();
        playerHealth = GetComponent<PlayerHealth>();
        wait = true;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire2") && wait && Time.timeScale != 0) {
            StartCoroutine(playerInvinsible());
            GameObject shieldInstance = Instantiate(forceShield, transform.position, transform.rotation);
            shieldInstance.transform.parent = gameObject.transform;
            Destroy(shieldInstance, 1f);
        }
    }

    IEnumerator playerInvinsible() {
        playerHealth.invinsible = true;
        wait = false;
        yield return new WaitForSeconds(1f);
        playerHealth.invinsible = false;
        yield return new WaitForSeconds(3f);
        wait = true;
    }
}
