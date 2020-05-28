using System.Collections;
using UnityEngine;

public class ActivateRadialAttack : MonoBehaviour {
    public GameObject bullet;
    public Transform shootPoint;
    private bool wait;
    public float waitTime;
    
    void Start() {
        wait = true;
    }

    void Update() {
        if (Input.GetButtonDown("Fire2") && wait && Time.timeScale != 0) {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack() {
        wait = false;

        for (int i = 0; i <= 360; i += 20) {
            shootPoint.transform.rotation = Quaternion.Euler(0, 0, i);
            GameObject bulletInstantiated = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            Rigidbody2D bulletRB = bulletInstantiated.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(shootPoint.right * 15, ForceMode2D.Impulse);
            SoundManager.PlaySound("EnergyShot");
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(waitTime);
        wait = true;
    }
}
