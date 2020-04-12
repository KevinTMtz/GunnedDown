using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_RadialShoot : MonoBehaviour
{
    private Transform shootPoint;

    public GameObject bullet;

    private float bulletForce = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        shootPoint = transform.parent.transform.Find("Cannon").transform;
    }

    public void ShootInCircle () {
        for (int i=0; i<=360; i+=20) {
            shootPoint.transform.rotation = Quaternion.Euler(0, 0, i);
            GameObject bulletInstantiated = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            Rigidbody2D bulletRB = bulletInstantiated.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void PlayBreathSound() {
        SoundManager.PlaySound("MinotaurBreath");
    }
}
