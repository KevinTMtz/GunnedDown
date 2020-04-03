using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateForceShield : MonoBehaviour
{
    private GameObject forceShield;

    private CapsuleCollider2D bc2d;

    private PlayerHealth playerHealth;

    private bool wait;
    
    // Start is called before the first frame update
    void Start()
    {
        forceShield = (GameObject) Resources.Load("Prefabs/PlayerAbilities/ForceShield", typeof(GameObject));

        bc2d = GetComponent<CapsuleCollider2D>();

        playerHealth = GetComponent<PlayerHealth>();

        wait = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && wait) {
            StartCoroutine(waitToRepeat());
            StartCoroutine(playerInvinsible());
            GameObject shieldInstance = Instantiate(forceShield, transform.position, transform.rotation);
            shieldInstance.transform.parent = gameObject.transform;
        }
    }

    IEnumerator playerInvinsible() {
        playerHealth.invinsible = true;
        yield return new WaitForSeconds(2f);
        playerHealth.invinsible = false;
    }

    IEnumerator waitToRepeat() {
        wait = false;
        yield return new WaitForSeconds(5f);
        wait = true;
    }
}
