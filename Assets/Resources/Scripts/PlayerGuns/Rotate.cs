using UnityEngine;

public class Rotate : MonoBehaviour {
    // Gun
    private GameObject gun;
    private Rigidbody2D rb;

    // Bullet
    private GameObject bullet;
    private Shoot shoot;
    
    // Player hand
    private GameObject hand;
    private Vector2 handPosition;
    
    // Gun Rotation
    private float aimAngle;
    private bool isFlipped = false;

    private GameObject muzzle1;

    void Start() {
        // Get RigidBody of the gun
        rb = gameObject.GetComponent<Rigidbody2D>();
        // Get hand of player
        hand = GameObject.Find("Hand");
        // Get gun
        gun = GameObject.Find("Gun");

        // TODO: If statement for that changes bullet depending on gun
        // Load bullet prefab
        shoot = gameObject.GetComponent<Shoot>();
        bullet = Resources.Load<GameObject>(shoot.bulletPath);
        muzzle1 = Resources.Load<GameObject>("Prefabs/Effects/ShotEffect1");
    }

    // Update is called once per frame
    void Update() {
        moveWithHand();
    }

    void FixedUpdate() {
        followAimPoint();
        rotateGun();
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
            muzzle1.GetComponent<SpriteRenderer>().sortingOrder = 8;
        } else {
            gun.GetComponent<SpriteRenderer>().sortingOrder = 12;
            bullet.GetComponent<SpriteRenderer>().sortingOrder = 11;
            muzzle1.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
    }

    // Move Aim Point
    void followAimPoint() {
        // Get vector relative to gun and mouse position in camera
        Vector2 aim = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim *= -0.5f;

        // Get angle of the aim vector
        aimAngle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
    }
}
