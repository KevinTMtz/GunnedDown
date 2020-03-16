using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private GameObject aimPoint;
    private Rigidbody2D aimRb2D;

    private Camera cam;

    private float angleOfAim = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //Hide mouse cursor
        Cursor.visible = false;

        aimPoint = GameObject.Find("AimPoint");
        aimRb2D = aimPoint.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        MoveAimPoint();
    }

    // Move Aim Point
    void MoveAimPoint() {
        // Get vector relative to player and mouse position in camera
        Vector2 aim = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim *= -1f;
        aimPoint.transform.localPosition = aim;

        // Get angle of the aim vector
        angleOfAim = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;

        /*
        aim.x += transform.position.x;
        aim.y += transform.position.y;
        aimRb2D.MovePosition(aim);
        */
    }

    public float AngleOfAim {
        get { return angleOfAim; }
    }
}
