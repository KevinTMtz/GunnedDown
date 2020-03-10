using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Get player
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        moveWithPlayer();
    }

    void moveWithPlayer() {
        playerPosition = player.transform.position;
        playerPosition.z = -10;
        transform.position = playerPosition;
    }
}
