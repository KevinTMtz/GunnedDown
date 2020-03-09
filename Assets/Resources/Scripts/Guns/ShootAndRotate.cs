using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndRotate : MonoBehaviour
{
    private GameObject gun;
    private float gunRotation;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private Transform shootPoint;
    private GameObject bullet;
    private float bulletForce = 50f;
    
    private GameObject hand;
    private Vector2 handPosition;
    
    private PlayerAim playerAim;
    private float aimAngle;
    private bool isFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        // To get aimAngle of PlayerAim
        playerAim = GameObject.Find("Player").GetComponent("PlayerAim") as PlayerAim;

        // Get RigidBody of the gun
        rb = gameObject.GetComponent<Rigidbody2D>();

        // Get Spriterenderer of the gun
        sr = gameObject.GetComponent<SpriteRenderer>();

        // Get hand of player
        hand = GameObject.Find("Hand");

        // Get gun
        gun = GameObject.Find("Gun");

        shootPoint = GameObject.Find("ShootPoint").transform;
        bullet = (GameObject) Resources.Load("Prefabs/Bullets/Bullet", typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {
        MoveAimPoint();

        moveWithHand();
        rotateGun();

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        GameObject bulletInstantiated = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D bulletRB = bulletInstantiated.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);
    }

    void moveWithHand() {
        handPosition = hand.transform.position;
        transform.position = handPosition;
    }

    void rotateGun() {
        rb.rotation = aimAngle;

        if (Mathf.Abs(aimAngle) > 90 && !isFlipped) {
            gameObject.transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            isFlipped = true;
        } else if (Mathf.Abs(aimAngle) < 90 && isFlipped) {
            gameObject.transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            isFlipped = false;
        }

        if (aimAngle > 22.5 && aimAngle < 157.5) {
            gun.GetComponent<SpriteRenderer>().sortingOrder = 9;
            bullet.GetComponent<SpriteRenderer>().sortingOrder = 8;
        } else {
            gun.GetComponent<SpriteRenderer>().sortingOrder = 12;
            bullet.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
    }

    // Move Aim Point
    void MoveAimPoint() {
        // Get vector relative to gun and mouse position in camera
        Vector2 aim = GameObject.Find("ShootPoint").transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim *= -0.5f;

        // Get angle of the aim vector
        aimAngle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
    }
}
