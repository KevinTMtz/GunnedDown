using System.Collections;
using UnityEngine;

public class ActivateTurret : MonoBehaviour {
    public GameObject turret;
    private bool wait;
    public float waitTime;
    
    void Start() {
        wait = true;
    }

    void Update() {
        if (Input.GetButtonDown("Fire2") && wait && Time.timeScale != 0) {
            StartCoroutine(waitToTurret());
            Instantiate(turret, new Vector2(transform.position.x, transform.position.y+0.5f), transform.rotation);
        }
    }

    IEnumerator waitToTurret() {
        wait = false;
        yield return new WaitForSeconds(waitTime);
        wait = true;
    }
}
