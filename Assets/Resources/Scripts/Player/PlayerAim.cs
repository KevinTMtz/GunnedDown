using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public GameObject aimPoint;
    public Camera cam;

    private float angleOfAim = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAimPoint();
    }

    // Move Aim Point
    void MoveAimPoint() {
        // Get vector relative to player and mouse position in camera
        Vector2 aim = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim *= -0.5f;
        aimPoint.transform.localPosition = aim;

        // Get angle of the aim vector
        angleOfAim = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
    }

    public float AngleOfAim {
        get { return angleOfAim; }
    }
}
