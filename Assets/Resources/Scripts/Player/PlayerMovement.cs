using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement attributes
    private Vector3 movementSpeed;
    private float speedX;
    private float speedY;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("PlaySound", 0.0f, Random.Range(0.25f, 0.45f));
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void PlaySound() {
        if (Mathf.Abs(speedX) > 0 || Mathf.Abs(speedY) > 0)
            SoundManager.PlaySound("Steps");
    }

    // Player movement
    void Movement() {
        float movementFactor = 10f;
        speedX = Input.GetAxis("Horizontal") * movementFactor;
        speedY = Input.GetAxis("Vertical") * movementFactor;
        movementSpeed = new Vector3(speedX, speedY, 0f);
        //transform.position = transform.position + movementSpeed;
        gameObject.GetComponent<Rigidbody2D>().velocity = movementSpeed;
    }
}
