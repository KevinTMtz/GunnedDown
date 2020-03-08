using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement attributes
    Vector3 movementSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    // Player movement
    void Movement() {
        float movementFactor = 0.25f;
        float speedX = Input.GetAxis("Horizontal") * movementFactor;
        float speedY = Input.GetAxis("Vertical") * movementFactor;
        movementSpeed = new Vector3(speedX, speedY, 0f);
        transform.position = transform.position + movementSpeed;
    }
}
