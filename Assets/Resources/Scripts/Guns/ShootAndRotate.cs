using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndRotate : MonoBehaviour
{
    private float gunRotation;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private Transform shootPoint;
    private GameObject bullet;
    private float bulletForce = 35f;
    
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

        shootPoint = GameObject.Find("ShootPoint").transform;
        bullet = (GameObject) Resources.Load("Prefabs/Bullets/Bullet", typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {
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
        aimAngle = playerAim.AngleOfAim;
        rb.rotation = aimAngle;

        if (Mathf.Abs(aimAngle) > 90 && !isFlipped) {
            gameObject.transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            isFlipped = true;
        } else if (Mathf.Abs(aimAngle) < 90 && isFlipped) {
            gameObject.transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            isFlipped = false;
        }
    }
}
