using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Movement attributes
    private Vector3 movementSpeed;
    private float speedX;
    private float speedY;

    public GameObject dust;
    private bool canDust;
    
    void Start() {
        InvokeRepeating ("PlaySound", 0.0f, Random.Range(0.25f, 0.45f));
        canDust = true;
    }

    void Update() {
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

        if (movementSpeed.magnitude > 0 && canDust)
            StartCoroutine(WaitToDust());

        gameObject.GetComponent<Rigidbody2D>().velocity = movementSpeed;
        if (speedX != 0 || speedY != 0)
            gameObject.GetComponent<Animator>().SetBool("isMoving", true);
        else
            gameObject.GetComponent<Animator>().SetBool("isMoving", false);
    }

    private IEnumerator WaitToDust () {
        canDust = !canDust;
        yield return new WaitForSeconds(Random.Range(0.15f, 0.25f));
        canDust = !canDust;
        if (movementSpeed.magnitude > 0)
            Instantiate(dust, transform.Find("Shadow").transform.position, Quaternion.identity);
    }
}
