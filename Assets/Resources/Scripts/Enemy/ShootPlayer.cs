using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    // Bullet
    private Transform shootPoint;
    private GameObject bullet;
    private float bulletForce = 10f;
    private string path;

    private bool ableToShoot;

    // Cannon Rotation
    private float aimAngle;

    private GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        ableToShoot = true;
        
        SelectBullet();

        // Get shootpoint transform and load bullet prefab
        shootPoint = transform.Find("Cannon");

        bullet = (GameObject) Resources.Load(path, typeof(GameObject));

        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (ableToShoot) { 
            StartCoroutine(ShootBullet());
            ableToShoot = false;
        }
        
        rotateCannon();
    }

    IEnumerator ShootBullet() {
        yield return new WaitForSeconds(1.5f);
        GameObject bulletInstantiated = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D bulletRB = bulletInstantiated.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);
        
        ableToShoot = true;
    }

    // Choose bullet depending on gun
    string SelectBullet() {
        path = "Prefabs/EnemyBullets/Bullet ";
        string gameObjectName = gameObject.name.Substring(0,6);

        if (gameObjectName.Equals("Enemy1")) {
            path += "1";
        } else if (gameObjectName.Equals("Enemy3")) {
            path += "2";
        }

        return path;
    }

    // Move Aim Point
    void rotateCannon() {
        // Get vector relative to enemy and player
        Vector2 aim = gameObject.transform.position - target.transform.position;
        aim *= -1f;

        // Get angle of the aim vector
        aimAngle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
        shootPoint.transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }

    public string bulletPath {
        get { return SelectBullet(); }
    }
}
