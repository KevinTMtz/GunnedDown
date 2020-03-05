using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public GameObject aimPoint;
    
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
        Vector3 aim = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        aim.Normalize();
        aim *= -2f;
        aimPoint.transform.localPosition = aim;
    }
}
