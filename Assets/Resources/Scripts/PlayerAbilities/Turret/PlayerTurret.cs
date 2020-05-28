using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour {
    private Rigidbody2D rb;
    
    public GameObject turretHead;
    private Animator turretHeadAnimator;

    private Queue<Transform> targets = new Queue<Transform>();
    private Transform target;
    public Transform shootPoint;

    private float aimAngle;
    private bool isFlipped = false;

    public GameObject bullet;
    private float bulletForce = 25f;

    private float startTime;
    public float durationTime;

    public GameObject explosion;
    
    void Start() {
        rb = turretHead.GetComponent<Rigidbody2D>();
        turretHeadAnimator = turretHead.GetComponent<Animator>();
        startTime = Time.time;
    }

    void Update() {
        if (target != null) {
            turretHeadAnimator.SetBool("Shooting", true);
            RotateTurretHead();
            UpdateAngle();
        } else if (target == null && targets.Count > 0) {
            target = targets.Dequeue();
        } else {
            turretHeadAnimator.SetBool("Shooting", false);
        }

        if (Time.time - startTime > durationTime) {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void ShootEnemies() {
        GameObject bulletInstantiated = Instantiate(bullet, shootPoint.position, shootPoint.rotation);

        Rigidbody2D bulletRB = bulletInstantiated.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);

        SoundManager.PlaySound("Shoot2");
    }

    private void RotateTurretHead() {
        rb.rotation = aimAngle;
        if (Mathf.Abs(aimAngle) > 90 && !isFlipped) {
            turretHead.transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            isFlipped = true;
        } else if (Mathf.Abs(aimAngle) < 90 && isFlipped) {
            turretHead.transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            isFlipped = false;
        }
    }

    void UpdateAngle() {
        // Get vector relative to turrethead and enemy position
        Vector2 aim = turretHead.transform.position - target.position;
        aim *= -0.5f;
        // Get angle of the aim vector
        aimAngle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (target == null && (other.CompareTag("Enemy") || other.CompareTag("Boss") || other.CompareTag("Hydra")))
            targets.Enqueue(other.gameObject.transform);
    }
}
