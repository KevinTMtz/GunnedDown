using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndRotate : MonoBehaviour
{
    // Gun
    private GameObject gun;
    private Rigidbody2D rb;

    // Bullet
    private Transform shootPoint;
    private GameObject bullet;
    private float bulletForce = 50f;
    
    // Player hand
    private GameObject hand;
    private Vector2 handPosition;
    
    // Gun Rotation
    private float aimAngle;
    private bool isFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get RigidBody of the gun
        rb = gameObject.GetComponent<Rigidbody2D>();

        // Get hand of player
        hand = GameObject.Find("Hand");

        // Get gun
        gun = GameObject.Find("Gun");

        // TODO: If statement for that changes bullet depending on gun
        // Get shootpoint transform and load bullet prefab
        shootPoint = GameObject.Find("ShootPoint").transform;
        bullet = (GameObject) Resources.Load("Prefabs/Bullets/Bullet", typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {
        followAimPoint();
        moveWithHand();
        rotateGun();

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    // Instantiate bullet
    void Shoot() {
        GameObject bulletInstantiated = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D bulletRB = bulletInstantiated.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);
    }

    // Place gun in player hand
    void moveWithHand() {
        handPosition = hand.transform.position;
        transform.position = handPosition;
    }

    void rotateGun() {
        rb.rotation = aimAngle;

        // Rotate gun relative to aimpoint
        if (Mathf.Abs(aimAngle) > 90 && !isFlipped) {
            gameObject.transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            isFlipped = true;
        } else if (Mathf.Abs(aimAngle) < 90 && isFlipped) {
            gameObject.transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            isFlipped = false;
        }

        // Change the order in layer of gun and bullets
        if (aimAngle > 22.5 && aimAngle < 157.5) {
            gun.GetComponent<SpriteRenderer>().sortingOrder = 9;
            bullet.GetComponent<SpriteRenderer>().sortingOrder = 8;
        } else {
            gun.GetComponent<SpriteRenderer>().sortingOrder = 12;
            bullet.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
    }

    // Move Aim Point
    void followAimPoint() {
        // Get vector relative to gun and mouse position in camera
        Vector2 aim = GameObject.Find("ShootPoint").transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim *= -0.5f;

        // Get angle of the aim vector
        aimAngle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
    }
}
