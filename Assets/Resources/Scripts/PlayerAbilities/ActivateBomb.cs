using System.Collections;
using UnityEngine;

public class ActivateBomb : MonoBehaviour {
    public GameObject bomb;
    private bool wait;
    public float waitTime;
    public Transform shootPoint;
    private float aimAngle;
    
    void Start() {
        wait = true;
    }

    void Update() {
        if (Input.GetButtonDown("Fire2") && wait && Time.timeScale != 0) {
            StartCoroutine(waitToBomb());
            GameObject bombInstantiated = Instantiate(bomb, transform.position, transform.rotation);
            if (Mathf.Abs(aimAngle) > 90 && Mathf.Abs(aimAngle) < 270)
                bombInstantiated.GetComponent<SpriteRenderer>().flipX = true;

            Rigidbody2D bombRB = bombInstantiated.GetComponent<Rigidbody2D>();
            bombRB.AddForce(shootPoint.right * 7, ForceMode2D.Impulse);
        }

        followAimPoint();
    }

    IEnumerator waitToBomb() {
        wait = false;
        yield return new WaitForSeconds(waitTime);
        wait = true;
    }

    // Move Aim Point
    void followAimPoint() {
        // Get vector relative to gun and mouse position in camera
        Vector2 aim = shootPoint.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim *= -0.5f;

        // Get angle of the aim vector
        aimAngle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
        if (aimAngle < 0)
            aimAngle = 360 + aimAngle;

        shootPoint.rotation = Quaternion.Euler(0, 0, aimAngle);
    }
}
