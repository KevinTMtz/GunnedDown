using UnityEngine;

public class PlayerAim : MonoBehaviour {
    private GameObject aimPoint;
    private Rigidbody2D aimRb2D;

    void Start() {
        aimPoint = GameObject.Find("AimPoint");
        aimRb2D = aimPoint.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        MoveAimPoint();
    }

    void MoveAimPoint() {
        // Get vector relative to player and mouse position in camera
        Vector2 aim = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim *= -1f;
        aimPoint.transform.localPosition = aim;

        // Get angle of the aim vector
        AngleOfAim = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
    }

    public float AngleOfAim { get; private set; } = 0;
}
