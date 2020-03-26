using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject fire;
    public Transform shootPoint;
    public GameObject target;
    public float fireForce;
    //private bool canShoot;
    //public float timeToWait;
    private float aimAngle;
    // Start is called before the first frame update
    void Start()
    {
        //canShoot = true;
        fireForce = 15f;
        //timeToWait = 5f;
    }
    //Aim player
    void rotateFirePoint()
    {
        Vector2 aim = gameObject.transform.position - target.transform.position;
        //aim *= -1f;

        aimAngle = Mathf.Atan2(-aim.x, aim.y) * Mathf.Rad2Deg;
        shootPoint.transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }
    public void ShootFireball()
    {
        //Aim the player
        rotateFirePoint();
        //Then shoot a Fireball
        GameObject fireball = Instantiate(fire, shootPoint.position, shootPoint.rotation);
        Rigidbody2D firballRigidbody = fireball.GetComponent<Rigidbody2D>();
        firballRigidbody.AddForce(-shootPoint.up * fireForce, ForceMode2D.Impulse);
    }
    public void ShootBlitz()
    {
        //Invoke repeating fireballs to make a blitz effect
        InvokeRepeating("ShootFireball", 0, 0.1f);
    }
    public void ShootBurst()
    {
        //Invoke repeating fireballs wit a deltaX to make a burst effect
        InvokeRepeating("BurstAim", 0f, 0.15f);
    }
    private void BurstAim()
    {
        //Aim near the player randomly
        Vector2 aim = gameObject.transform.position - target.transform.position;
        aimAngle = Mathf.Atan2(-aim.x + Random.Range(-5, 5), aim.y) * Mathf.Rad2Deg;
        shootPoint.transform.rotation = Quaternion.Euler(0, 0, aimAngle);
        //Shoot a Fireball
        GameObject fireball = Instantiate(fire, shootPoint.position, shootPoint.rotation);
        Rigidbody2D firballRigidbody = fireball.GetComponent<Rigidbody2D>();
        firballRigidbody.AddForce(-shootPoint.up * fireForce, ForceMode2D.Impulse);
    }
    public void StopFiring()
    {
        CancelInvoke();
    }
        // Update is called once per frame
        /*void Update()
        {
            if (canShoot)
            {
                StartCoroutine(ShootFireBall());
                canShoot = false;
            }
            rotateFirePoint();
        }

        private IEnumerator ShootFireBall()
        {
            if (blitzActivated)
            {
                InvokeRepeating("ShootBlitz", 2f, 0.175f);
                yield return new WaitForSeconds(timeToWait);
                CancelInvoke();
            }
            else
            {
                yield return new WaitForSeconds(timeToWait);
                GameObject fireball = Instantiate(fire, shootPoint.position, shootPoint.rotation);
                Rigidbody2D firballRigidbody = fireball.GetComponent<Rigidbody2D>();
                firballRigidbody.AddForce(-shootPoint.up * fireForce, ForceMode2D.Impulse);
            }
            canShoot = true;
            /*yield return new WaitForSeconds(timeToWait);
            GameObject fireball = Instantiate(fire, shootPoint.position, shootPoint.rotation);
            Rigidbody2D firballRigidbody = fireball.GetComponent<Rigidbody2D>();
            firballRigidbody.AddForce(-shootPoint.up * fireForce, ForceMode2D.Impulse);
            canShoot = true;
        }
        private void ShootBlitz()
        {
            GameObject fireball = Instantiate(fire, shootPoint.position, shootPoint.rotation);
            Rigidbody2D firballRigidbody = fireball.GetComponent<Rigidbody2D>();
            firballRigidbody.AddForce(-shootPoint.up * fireForce, ForceMode2D.Impulse);
        }
*/
}
