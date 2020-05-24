using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTurret : MonoBehaviour
{
    public GameObject turret;
    private bool wait;
    public float waitTime;
    
    // Start is called before the first frame update
    void Start()
    {
        wait = true;
    }

    // Update is called once per frame
    void Update()
    {
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
