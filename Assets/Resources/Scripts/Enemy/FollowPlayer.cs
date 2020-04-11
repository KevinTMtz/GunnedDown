using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //private float speed = 2.5f;
    private Transform target;

    private SpriteRenderer spriteRenderer;

    private bool facingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Vector2.Distance(transform.position, target.position) > 3)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        */

        flipEnemySprite();
    }

    void flipEnemySprite() {
        if (90 > Mathf.Abs(getAngleRelToPlayer()) && facingRight == false) {
            Flip();
        } else if (90 < Mathf.Abs(getAngleRelToPlayer()) && facingRight == true) {
            Flip();
        }
    }

    void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }

    float getAngleRelToPlayer() {
        // Get vector relative to enemy and player
        Vector2 aim = gameObject.transform.position - target.transform.position;
        aim *= -1f;

        // Get angle of the aim vector
        return Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
    }
}
